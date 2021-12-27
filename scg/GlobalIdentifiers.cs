namespace scg
{
    public static class GlobalIdentifiers
    {
        /// <summary>
        /// This is the ID of the yearly Solo Challenges geeklist. Needs to be updated once a year.
        /// </summary>
#if DEBUG
        public static readonly int GeekListId = 291214; // For testing purposes.
#else
        public static readonly int GeekListId = 293469; // Solo challenges 2022.
#endif
    }
}