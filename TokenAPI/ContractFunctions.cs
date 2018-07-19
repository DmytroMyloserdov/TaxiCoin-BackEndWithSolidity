using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TokenAPI.Events;

namespace TokenAPI
{
    public class ContractFunctions
    {
        public string Abi { get; set; }
        public string ByteCode { get; set; }
        public string ContractAddress { get; set; }
        public List<EventLog<PaymentCreatiedEvent>> Log { get; set; }

        public ContractFunctions(string abi, string byteCode)
        {
            Abi = abi;
            ByteCode = byteCode;
            Log = new List<EventLog<PaymentCreatiedEvent>>();
        }

        public async Task DeployContract(string senderAddress, string password, long gas, long totalSupply)
        {
            var web3 = GetWeb3Account(senderAddress, password);

            var receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(Abi, ByteCode, senderAddress, new Nethereum.Hex.HexTypes.HexBigInteger(gas), null, totalSupply);
            ContractAddress = receipt.ContractAddress;
        }

        public async Task<TypeOfResult> CallFunctionByName<TypeOfResult>(string senderAddress, string password, string functionName, Type returnType, params object[] parametrsOfFunction) where TypeOfResult : class
        {
            var web3 = GetWeb3Account(senderAddress, password);

            var contract = web3.Eth.GetContract(Abi, ContractAddress);
            var calledFunction = contract.GetFunction(functionName);

            if (functionName == FunctionAndEventsNames.CreatePayment)
            {
                return await LogChangesAndReturnResult<TypeOfResult>(calledFunction, contract);
            }
            else
            {
                var result = await calledFunction.CallAsync<TypeOfResult>(parametrsOfFunction);
                return result;
            }
        }


        private Web3 GetWeb3Account(string senderAddress, string password)
        {
            var account = new ManagedAccount(senderAddress, password);
            return new Web3(account);
        }
        
        private async Task<TRes> LogChangesAndReturnResult<TRes>(Function func, Contract contract) where TRes : class
        {
            var funcEvent = contract.GetEvent(FunctionAndEventsNames.PaymentCreationEvent);

            var filter = await funcEvent.CreateFilterAsync();

            var res = await func.CallAsync<TRes>();

            var log = await funcEvent.GetFilterChanges<PaymentCreatiedEvent>(filter);
            Log.AddRange(log);

            return res;
        }
    }
}
