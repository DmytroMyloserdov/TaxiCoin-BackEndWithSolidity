﻿using App.RequestObjectPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI;

namespace App.Utils
{
    public class TokenFunctionsResults<TResult, TPattern> where TPattern : IControllerPattern
    {
        public static TResult Invoke(UInt64 id, TPattern req, string funcName)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);

            return contractFunctions.CallFunctionByName<TResult>(senderAddress, password, funcName, id).Result;
        }
    }
}
