// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.Overlays
{
    public abstract partial class Overlay
    {
        internal struct LockedAnchor : IDisposable
        {
            Overlay m_Target;

            public LockedAnchor(Overlay target)
            {
                m_Target = target;
                m_Target.m_LockAnchor = true;
            }

            public void Dispose()
            {
                m_Target.m_LockAnchor = false;
            }
        }

        internal SnapCorner floatingSnapCorner { get; private set; } = SnapCorner.TopLeft;

        internal Vector2 floatingSnapOffset
        {
            get => m_FloatingSnapOffset + m_SnapOffsetDelta;

            private set
            {
                if (m_FloatingSnapOffset == value)
                    return;

                m_FloatingSnapOffset = value;
                m_SnapOffsetDelta = Vector2.zero;
                UpdateAbsolutePosition();
                floatingPositionChanged?.Invoke(floatingPosition);
            }
        }

        // overlay floating position in window
        public Vector2 floatingPosition
        {
            get => SnapToFloatingPosition(floatingSnapCorner, m_LockAnchor ? m_FloatingSnapOffset : floatingSnapOffset);
            set
            {
                var position = canvas.ClampToOverlayWindow(new Rect(value, rootVisualElement.rect.size)).position;
                UpdateSnapping(position);
            }
        }

        public bool floating
        {
            get => m_Floating;
            internal set
            {
                if (m_Floating == value) return;
                m_Floating = value;
                OnFloatingChanged(value);
            }
        }

        void OnFloatingChanged(bool floating)
        {
            if (floating)
                UpdateAbsolutePosition();

            floatingChanged?.Invoke(floating);
        }

        internal bool DockAt(OverlayContainer container, OverlayContainerSection section)
        {
            return DockAt(container, section, container.GetSectionCount(section));
        }

        internal bool DockAt(OverlayContainer container, OverlayContainerSection section, int index)
        {
            //If the overlay is staying in the same container
            if (container.GetOverlayIndex(this, out var originSection, out var originIndex))
            {
                if (originSection == section && originIndex == index)
                    return true;

                //If the overlay was before the index, removing it will change the size of the container
                if (originSection == section && originIndex < index)
                    --index;
            }

            this.container?.RemoveOverlay(this);

            this.container = container;
            this.container.InsertOverlay(this, section, index);

            floating = container is FloatingOverlayContainer;

            RebuildContent();

            return true;
        }

        internal bool DockBefore(Overlay target)
        {
            if (target.container == null)
                throw new ArgumentException("Target overlay has an invalid container", nameof(target));

            var container = target.container;
            container.GetOverlayIndex(target, out var section, out var index);
            return DockAt(container, section, index);
        }

        internal bool DockAfter(Overlay target)
        {
            if (target.container == null)
                throw new ArgumentException("Target overlay has an invalid container", nameof(target));

            var container = target.container;
            container.GetOverlayIndex(target, out var section, out var index);
            return DockAt(container, section, index + 1);
        }

        public void Undock()
        {
            if (floating)
                return;

            DockAt(canvas.floatingContainer, OverlayContainerSection.BeforeSpacer, canvas.floatingContainer.GetSectionCount(OverlayContainerSection.BeforeSpacer));
        }

        internal void BringToFront()
        {
            if (!(container is FloatingOverlayContainer))
                return;

            DockAt(container, OverlayContainerSection.BeforeSpacer, container.GetSectionCount(OverlayContainerSection.BeforeSpacer));
        }

        internal void SetSnappingOffset(Vector2 snapOffset, Vector2 snapOffsetDelta)
        {
            m_FloatingSnapOffset = snapOffset;
            m_SnapOffsetDelta = snapOffsetDelta;
            UpdateAbsolutePosition();
            floatingPositionChanged?.Invoke(floatingPosition);
        }

        Vector2 SnapToFloatingPosition(SnapCorner corner, Vector2 snapPosition)
        {
            switch (corner)
            {
                case SnapCorner.TopLeft:
                    return snapPosition;
                case SnapCorner.TopRight:
                    return new Vector2(canvas.floatingContainer.localBound.width + snapPosition.x, snapPosition.y);
                case SnapCorner.BottomLeft:
                    return new Vector2(snapPosition.x, canvas.floatingContainer.localBound.height + snapPosition.y);
                case SnapCorner.BottomRight:
                    return canvas.floatingContainer.localBound.size + snapPosition;
                default:
                    return Vector2.zero;
            }
        }

        void FloatingToSnapPosition(Vector2 position, out Vector2 snapOffset)
        {
            Rect containerRect = canvas.floatingContainer.localBound;
            Rect overlayRect = new Rect(position, rootVisualElement.localBound.size);
            Vector2 snapCornerPosition;
            switch (floatingSnapCorner)
            {
                case SnapCorner.TopRight:
                    snapCornerPosition = containerRect.position + new Vector2(containerRect.width, 0);
                    break;
                case SnapCorner.BottomLeft:
                    snapCornerPosition = containerRect.position + new Vector2(0, containerRect.height);
                    break;
                case SnapCorner.BottomRight:
                    snapCornerPosition = containerRect.max;
                    break;
                case SnapCorner.TopLeft:
                default:
                    snapCornerPosition = containerRect.position;
                    break;
            }

            snapOffset = overlayRect.position - snapCornerPosition;
        }

        void FloatingToSnapPosition(Vector2 position, out SnapCorner snapCorner, out Vector2 snapOffset)
        {
            Rect containerRect = canvas.floatingContainer.localBound;
            var aTopLeft = containerRect.position;
            var aTopRight = containerRect.position + new Vector2(containerRect.width, 0);
            var aBottomLeft = containerRect.position + new Vector2(0, containerRect.height);
            var aBottomRight = containerRect.max;

            Rect overlayRect = new Rect(position, rootVisualElement.localBound.size);
            var bTopLeft = overlayRect.position;
            var bTopRight = overlayRect.position + new Vector2(overlayRect.width, 0);
            var bBottomLeft = overlayRect.position + new Vector2(0, overlayRect.height);
            var bBottomRight = overlayRect.max;

            var topLeft = bTopLeft - aTopLeft;
            var topRight = bTopRight - aTopRight;
            var bottomLeft = bBottomLeft - aBottomLeft;
            var bottomRight = bBottomRight - aBottomRight;

            snapOffset = topLeft;
            snapCorner = SnapCorner.TopLeft;

            if (topRight.sqrMagnitude < snapOffset.sqrMagnitude)
            {
                snapOffset = overlayRect.position - aTopRight;
                snapCorner = SnapCorner.TopRight;
            }

            if (bottomLeft.sqrMagnitude < snapOffset.sqrMagnitude)
            {
                snapOffset = overlayRect.position - aBottomLeft;
                snapCorner = SnapCorner.BottomLeft;
            }

            if (bottomRight.sqrMagnitude < snapOffset.sqrMagnitude)
            {
                snapOffset = overlayRect.position - aBottomRight;
                snapCorner = SnapCorner.BottomRight;
            }
        }

        internal void OnGeometryChanged(GeometryChangedEvent evt)
        {
            if (evt.newRect.size != evt.oldRect.size && canvas.overlaysEnabled)
            {
                if (!m_ContentsChanged)
                    using (new LockedAnchor(this))
                        floatingPosition = floatingPosition;
            }

            // When visual state changes, we need to wait until geometry recalculates to enforce bounds clamping
            if(m_ContentsChanged)
                floatingPosition = floatingPosition;

            m_ContentsChanged = false;
        }

        void UpdateSnapping(Vector2 position)
        {
            //Protect against an update to the position while the canvas hasn't had its first geometry pass
            if (float.IsNaN(position.x) || float.IsNaN(position.y))
                return;

            if (m_LockAnchor)
            {
                //Anchor and position are locked, we only update the offsetDelta
                FloatingToSnapPosition(position, out var snapOffset);
                m_SnapOffsetDelta = snapOffset - m_FloatingSnapOffset;
            }
            else
            {
                FloatingToSnapPosition(position, out var snapCorner, out var snapOffset);
                floatingSnapCorner = snapCorner;
                floatingSnapOffset = snapOffset;
            }
        }

        internal void UpdateAbsolutePosition()
        {
            if (rootVisualElement.resolvedStyle.position == Position.Absolute)
                rootVisualElement.transform.position = floatingPosition;
        }
    }
}
