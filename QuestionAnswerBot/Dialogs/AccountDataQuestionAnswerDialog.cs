using System;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;

namespace Haskathon.QuestionAnswerBot.Controllers.Dialogs
{
    [Serializable]
    [QnAMaker("90b4ce22-2b4a-49d2-b074-c796ccf48c80", "68c9242b-3835-41d8-9836-39eb09c87c7f", endpointHostName: "https://qnaubsassist.azurewebsites.net/qnamaker")]
    public class AccountDataQuestionAnswerDialog : QnAMakerDialog
    {
		public AccountDataQuestionAnswerDialog()
		{
			WelcomeMessage = "What do you need to know regarding your account?";
		}
	}
}