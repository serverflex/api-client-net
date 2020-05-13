namespace BattleCrate.API.Schema
{
    public static class CrateState
    {
        #region Constant Values
        public const string Deleting = "deleting";
        public const string Deploying = "deploying";
        public const string Running = "running";
        public const string Starting = "starting";
        public const string Stopped = "stopped";
        public const string Stopping = "stopping";
        #endregion
    }
}
