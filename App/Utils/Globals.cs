using TokenAPI;

namespace App.Utils
{
    public class Globals
    {
        public ContractFunctions ContractFunctions { get; set; }
        public enum PaymentStatus { Pending, Completed, Refunded, GetByDriver }

        private static Globals Instance;
        private Globals() { }
        public static Globals GetInstance()
        {
            if (Instance == null)
                Instance = new Globals();
            return Instance;
        }
    }
}
