namespace BattleCrate.API.Operations
{
    public class CrateOperations : BaseOperations, ICrateOperations
    {
        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crates.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CrateOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
