﻿using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TokenAPI
{
    public class ContractFunctions
    {
        public string Abi { get; set; }
        public string ByteCode { get; set; }
        public string ContractAddress { get; set; }

        public ContractFunctions(string abi, string byteCode)
        {
            Abi = abi;
            ByteCode = byteCode;
        }

        public async void DeployContract(string senderAddress, string password, ulong gas, ulong totalSupply)
        {
            var web3 = GetWeb3Account(senderAddress, password);

            var receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(Abi, ByteCode, senderAddress, new Nethereum.Hex.HexTypes.HexBigInteger(gas), null, totalSupply);
            ContractAddress = receipt.ContractAddress;
        }

        public async Task<TypeOfResult> CallFunctionByName<TypeOfResult>(string senderAddress, string password, string functionName, params object[] parametrsOfFunction)
        {
            var web3 = GetWeb3Account(senderAddress, password);

            var contract = web3.Eth.GetContract(Abi, ContractAddress);
            var calledFunction = contract.GetFunction(functionName);

            var result = await calledFunction.CallAsync<TypeOfResult>(parametrsOfFunction);
            return result;
        }

        public async Task<TransactionReceipt> CallFunctionByName(string senderAddress, string password, string functionName, params object[] parametrsOfFunction)
        {
            var web3 = GetWeb3Account(senderAddress, password);

            var contract = web3.Eth.GetContract(Abi, ContractAddress);
            var calledFunction = contract.GetFunction(functionName);

            var gas = await calledFunction.EstimateGasAsync(senderAddress, null, null, parametrsOfFunction);
            var receipt = await calledFunction.SendTransactionAndWaitForReceiptAsync(senderAddress, gas, null, null, parametrsOfFunction);
            return receipt;
        }

        public async Task<string> GetUserBalance(string senderAddress, string password)
        {
            var web3 = GetWeb3Account(senderAddress, password);
            var res = await web3.Eth.GetBalance.SendRequestAsync(senderAddress);
            return res.Value.ToString();
        }

        public async Task<Payment> DeserializePaymentById(string senderAddress, string password, UInt64 id)
        {
            var web3 = GetWeb3Account(senderAddress, password);
            var contract = web3.Eth.GetContract(Abi, ContractAddress);
            var payments = contract.GetFunction("payments");

            var result = await payments.CallDeserializingToObjectAsync<Payment>(id);
            return result;
        }

        /*struct Payment {
            address Customer;
            address Driver; 
            uint value;
            PaymentStatus status;
            bool refundApproved;
            bool isValue;
        }*/

        [FunctionOutput]
        public class Payment
        {
            [Parameter("address", "Customer", 1)]
            string Customer { get; set; }
            [Parameter("address", "Driver", 2)]
            string Driver { get; set; }
            [Parameter("uint", "value", 3)]
            UInt64 Value { get; set; }
            [Parameter("PaymentStatus", "status", 4)]
            object Status { get; set; }
            [Parameter("bool", "refundApproved", 5)]
            bool RefundApproved { get; set; }
            [Parameter("bool", "isValue", 6)]
            bool IsValue { get; set; }
        }


        private Web3 GetWeb3Account(string senderAddress, string password)
        {
            var account = new ManagedAccount(senderAddress, password);
            return new Web3(account);
        }
    }
}
