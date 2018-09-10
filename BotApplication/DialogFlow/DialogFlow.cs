using ApiAiSDK;
using ApiAiSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApplication.Integrate
{
    public static class DialogFlow
    {

        public static string accessToken = "89c165e158f2400cbe369888333e6381";

        /// <summary>
        /// connecting to the dialogflow
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string getDialogfloW(Request request)
        {
            var config = new AIConfiguration(accessToken, SupportedLanguage.English);
            
            var dataService = new AIDataService(config);
            var aiRequest = new AIRequest(request.Message);
            var aiResponse = dataService.Request(aiRequest);

            var dialogflowresult = aiResponse.Result.Fulfillment.Speech;

            return dialogflowresult;
        }

    }
}

public class Request
{
    public string SessionId { get; set; }
    public string Message { get; set; }
}
