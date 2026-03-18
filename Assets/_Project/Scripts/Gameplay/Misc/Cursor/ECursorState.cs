namespace Project.Gameplay.Misc
{
    [System.Flags]
    public enum ECursorState
    {
        None = 0,
        HoverInventoryItem = 1,
        HoldInventoryItem = 2,
        
        HoverPickup = 4,
        HoverQuestion = 8,
        HoverWalkObject = 16,
        HoverPointer = 32,
        
        RotateRight = 64,
        RotateLeft = 128,
        MoveBack = 256,
        
        DownPointer = 512,
        Transition = 1024
    }
}