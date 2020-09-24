namespace BattleCrate.API.Schema
{
    public static class LockReason
    {
        #region Constant Values
        public const string Billing = "billing";
        public const string BillingDeleteTerminationProtection = "billing_delete_termination_protection";
        public const string BillingTrialCancelledTerminationProtection = "billing_trial_cancelled_termination_protection";
        public const string Maintenance = "maintenance";
        public const string TrialExpired = "trial_expired";
        #endregion
    }
}
