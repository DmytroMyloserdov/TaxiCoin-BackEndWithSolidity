﻿using App.Utils;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static App.Utils.Globals;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/test").Result;

                var globalsInstance = Globals.GetInstance();
                var abi = @"[{'constant':true,'inputs':[],'name':'name','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_spender','type':'address'},{'name':'_value','type':'uint256'}],'name':'approve','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'totalSupply','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_from','type':'address'},{'name':'_to','type':'address'},{'name':'_value','type':'uint256'}],'name':'transferFrom','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_orderId','type':'uint256'}],'name':'refund','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'INITIAL_SUPPLY','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'decimals','outputs':[{'name':'','type':'uint8'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_orderId','type':'uint256'}],'name':'approveRefund','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_spender','type':'address'},{'name':'_subtractedValue','type':'uint256'}],'name':'decreaseApproval','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'}],'name':'balanceOf','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'renounceOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'payments','outputs':[{'name':'Customer','type':'address'},{'name':'Driver','type':'address'},{'name':'value','type':'uint256'},{'name':'status','type':'uint8'},{'name':'refundApproved','type':'bool'},{'name':'isValue','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'owner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'symbol','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_orderId','type':'uint256'},{'name':'_value','type':'uint256'}],'name':'createPayment','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_to','type':'address'},{'name':'_value','type':'uint256'}],'name':'transfer','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_orderId','type':'uint256'}],'name':'completeOrder','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_orderId','type':'uint256'}],'name':'getOrder','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[],'name':'deposit','outputs':[{'name':'','type':'uint256'}],'payable':true,'stateMutability':'payable','type':'function'},{'constant':false,'inputs':[{'name':'_spender','type':'address'},{'name':'_addedValue','type':'uint256'}],'name':'increaseApproval','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'},{'name':'_spender','type':'address'}],'name':'allowance','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_newOwner','type':'address'}],'name':'transferOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'inputs':[],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'owner','type':'address'},{'indexed':true,'name':'spender','type':'address'},{'indexed':false,'name':'value','type':'uint256'}],'name':'Approval','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'from','type':'address'},{'indexed':true,'name':'to','type':'address'},{'indexed':false,'name':'value','type':'uint256'}],'name':'Transfer','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'previousOwner','type':'address'}],'name':'OwnershipRenounced','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'previousOwner','type':'address'},{'indexed':true,'name':'newOwner','type':'address'}],'name':'OwnershipTransferred','type':'event'}]";
                var byteCode = @"60c0604052600860808190527f54617869436f696e00000000000000000000000000000000000000000000000060a090815261003e91600491906100d1565b506040805180820190915260038082527f54584300000000000000000000000000000000000000000000000000000000006020909201918252610083916005916100d1565b506006805460ff191690556201d4c06007553480156100a157600080fd5b5060008054600160a060020a0319163390811782556007546002819055908252600160205260409091205561016c565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061011257805160ff191683800117855561013f565b8280016001018555821561013f579182015b8281111561013f578251825591602001919060010190610124565b5061014b92915061014f565b5090565b61016991905b8082111561014b5760008155600101610155565b90565b610f77806200017c6000396000f3006080604052600436106101275763ffffffff7c010000000000000000000000000000000000000000000000000000000060003504166306fdde03811461012c578063095ea7b3146101b657806318160ddd146101ee57806323b872dd14610215578063278ecde11461023f5780632ff2e9dc14610257578063313ce5671461026c578063348a71a61461029757806366188463146102af57806370a08231146102d3578063715018a6146102f457806387d817891461030b5780638da5cb5b1461037a57806395d89b41146103ab578063a6e7ed7a146103c0578063a9059cbb146103db578063b6adaaff146103ff578063d09ef24114610417578063d0e30db01461042f578063d73dd62314610437578063dd62ed3e1461045b578063f2fde38b14610482575b600080fd5b34801561013857600080fd5b506101416104a3565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561017b578181015183820152602001610163565b50505050905090810190601f1680156101a85780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156101c257600080fd5b506101da600160a060020a0360043516602435610531565b604080519115158252519081900360200190f35b3480156101fa57600080fd5b50610203610597565b60408051918252519081900360200190f35b34801561022157600080fd5b506101da600160a060020a036004358116906024351660443561059d565b34801561024b57600080fd5b50610203600435610716565b34801561026357600080fd5b506102036107a6565b34801561027857600080fd5b506102816107ac565b6040805160ff9092168252519081900360200190f35b3480156102a357600080fd5b506102036004356107b5565b3480156102bb57600080fd5b506101da600160a060020a036004351660243561084a565b3480156102df57600080fd5b50610203600160a060020a036004351661093a565b34801561030057600080fd5b50610309610955565b005b34801561031757600080fd5b506103236004356109c1565b60408051600160a060020a038089168252871660208201529081018590526060810184600381111561035157fe5b60ff16815292151560208401525015156040808301919091525190819003606001945092505050f35b34801561038657600080fd5b5061038f610a0b565b60408051600160a060020a039092168252519081900360200190f35b3480156103b757600080fd5b50610141610a1a565b3480156103cc57600080fd5b50610203600435602435610a75565b3480156103e757600080fd5b506101da600160a060020a0360043516602435610bb2565b34801561040b57600080fd5b50610203600435610c95565b34801561042357600080fd5b50610203600435610d09565b610203610d8d565b34801561044357600080fd5b506101da600160a060020a0360043516602435610dc2565b34801561046757600080fd5b50610203600160a060020a0360043581169060243516610e5b565b34801561048e57600080fd5b50610309600160a060020a0360043516610e86565b6004805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156105295780601f106104fe57610100808354040283529160200191610529565b820191906000526020600020905b81548152906001019060200180831161050c57829003601f168201915b505050505081565b336000818152600360209081526040808320600160a060020a038716808552908352818420869055815186815291519394909390927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925928290030190a350600192915050565b60025490565b6000600160a060020a03831615156105b457600080fd5b600160a060020a0384166000908152600160205260409020548211156105d957600080fd5b600160a060020a038416600090815260036020908152604080832033845290915290205482111561060957600080fd5b600160a060020a038416600090815260016020526040902054610632908363ffffffff610ea916565b600160a060020a038086166000908152600160205260408082209390935590851681522054610667908363ffffffff610ebb16565b600160a060020a0380851660009081526001602090815260408083209490945591871681526003825282812033825290915220546106ab908363ffffffff610ea916565b600160a060020a03808616600081815260036020908152604080832033845282529182902094909455805186815290519287169391927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef929181900390910190a35060019392505050565b60008181526008602052604081208160038083015460ff169081111561073857fe5b1480610754575060038181015460ff168181111561075257fe5b145b151561075f57600080fd5b8054600160a060020a0316331461077557600080fd5b6003810180546002919060ff19166001835b021790555060038082015460ff169081111561079f57fe5b9392505050565b60075481565b60065460ff1681565b6000805481908190600160a060020a031633146107d157600080fd5b60008481526008602052604090206003810154909250610100900460ff16156107f957600080fd5b8154600283015461081391600160a060020a031690610bb2565b905080151561082157600080fd5b6003808301805461ff001916610100179081905560ff169081111561084257fe5b949350505050565b336000908152600360209081526040808320600160a060020a03861684529091528120548083111561089f57336000908152600360209081526040808320600160a060020a03881684529091528120556108d4565b6108af818463ffffffff610ea916565b336000908152600360209081526040808320600160a060020a03891684529091529020555b336000818152600360209081526040808320600160a060020a0389168085529083529281902054815190815290519293927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929181900390910190a35060019392505050565b600160a060020a031660009081526001602052604090205490565b600054600160a060020a0316331461096c57600080fd5b60008054604051600160a060020a03909116917ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482091a26000805473ffffffffffffffffffffffffffffffffffffffff19169055565b6008602052600090815260409020805460018201546002830154600390930154600160a060020a0392831693919092169160ff808216916101008104821691620100009091041686565b600054600160a060020a031681565b6005805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156105295780601f106104fe57610100808354040283529160200191610529565b600082815260086020526040812060030154819062010000900460ff1615610a9c57600080fd5b600054610ab290600160a060020a031684610bb2565b9050801515610ac057600080fd5b6040805160c0810182523381526000602082018190529181018590529060608201908152600060208083018290526001604093840181905288835260088252918390208451815473ffffffffffffffffffffffffffffffffffffffff19908116600160a060020a039283161783559286015182850180549094169116179091559183015160028301556060830151600380840180549293909260ff1916918490811115610b6957fe5b021790555060808201516003909101805460a0909301511515620100000262ff0000199215156101000261ff001990941693909317919091169190911790556000949350505050565b6000600160a060020a0383161515610bc957600080fd5b33600090815260016020526040902054821115610be557600080fd5b33600090815260016020526040902054610c05908363ffffffff610ea916565b3360009081526001602052604080822092909255600160a060020a03851681522054610c37908363ffffffff610ebb16565b600160a060020a0384166000818152600160209081526040918290209390935580518581529051919233927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9281900390910190a350600192915050565b60008181526008602052604081208054600160a060020a03163314610cb957600080fd5b60038181015460ff1681811115610ccc57fe5b14610cd657600080fd5b60018101546002820154610cf391600160a060020a031690610bb2565b506003810180546001919060ff19168280610787565b60008181526008602052604081206001810154600160a060020a031615610d2f57600080fd5b600060038083015460ff1690811115610d4457fe5b14610d4e57600080fd5b6003818101805460ff191682179081905560018301805473ffffffffffffffffffffffffffffffffffffffff19163317905560ff169081111561079f57fe5b6000348110610d9b57600080fd5b50600280543490810190915533600090815260016020526040902080549091019081905590565b336000908152600360209081526040808320600160a060020a0386168452909152812054610df6908363ffffffff610ebb16565b336000818152600360209081526040808320600160a060020a0389168085529083529281902085905580519485525191937f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929081900390910190a350600192915050565b600160a060020a03918216600090815260036020908152604080832093909416825291909152205490565b600054600160a060020a03163314610e9d57600080fd5b610ea681610ece565b50565b600082821115610eb557fe5b50900390565b81810182811015610ec857fe5b92915050565b600160a060020a0381161515610ee357600080fd5b60008054604051600160a060020a03808516939216917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e091a36000805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a03929092169190911790555600a165627a7a723058203ac46e2a3bce584a601ea10b310013fefdab7779badecbf54dbb7c05fd5329d00029";
                globalsInstance.ContractFunctions = new TokenAPI.ContractFunctions(abi, byteCode);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Server is running on { baseAddress }");
                }
                else
                {
                    Console.WriteLine("Failed to run server");
                }
                Console.ReadLine();
            }
        }
    }
}
