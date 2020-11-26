namespace BlzrHstWasm.Shared.ViewModels
{
    public class OverlayViewModel { 

        public bool Active { get; set; } = false;

        public void ToggleActive() {
            Active = !Active;
        }
    }
}
