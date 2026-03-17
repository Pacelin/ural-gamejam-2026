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
        HoverPointer = 32
    }
}