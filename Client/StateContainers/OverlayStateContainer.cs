
using System;
using Microsoft.JSInterop;

namespace BlzrHstWasm.Client.StateContainers {

    public class OverlayStateContainer {
        
        public bool Active {set; get; } = false;

        public event Action OnChange;

        private readonly DotNetObjectReference<OverlayStateContainer> objectReference;
        private readonly IJSRuntime jSRuntime;

        public OverlayStateContainer(IJSRuntime jSRuntime) {
            this.jSRuntime = jSRuntime;
            objectReference = DotNetObjectReference.Create(this);
        }

        public void SetActive(bool active) {
            Active = active;
            OnChange?.Invoke();
        }

        [JSInvokable("OnWindowResize")]
        public void OnWindowResize(int width, int height) {
            Console.WriteLine($"[Window] width => {width}");
            Console.WriteLine($"[Window] height => {height}");
        }

        public void AttachWindowListener() {
            jSRuntime.InvokeVoidAsync(
                "window.Site.attachWindowResizeListener",
                objectReference
            );
        }

        public void DetachWindowListener() {
            jSRuntime.InvokeVoidAsync(
                "window.Site.detachWindowResizeListener",
                objectReference
            );
        }
    }
}