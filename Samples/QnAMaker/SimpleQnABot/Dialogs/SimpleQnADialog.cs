using System;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;

namespace SimpleQnABot.Dialogs
{
    [Serializable]
    // Below method uses the V2 APIs : https://aka.ms/qnamaker-v2-apis. 
    // To use V4 stack, you also need to add the Endpoint hostname to the parameters below : https://aka.ms/qnamaker-v4-apis
    [QnAMaker("90b4ce22-2b4a-49d2-b074-c796ccf48c80", "68c9242b-3835-41d8-9836-39eb09c87c7f", endpointHostName: "https://qnaubsassist.azurewebsites.net/qnamaker")]
    public class SimpleQnADialog : QnAMakerDialog
    {
    }
}