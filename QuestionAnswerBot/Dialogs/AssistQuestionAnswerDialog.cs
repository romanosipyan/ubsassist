using System;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Haskathon.QuestionAnswerBot.Controllers.Dialogs
{
    [Serializable]
    [QnAMaker("90b4ce22-2b4a-49d2-b074-c796ccf48c80", "68c9242b-3835-41d8-9836-39eb09c87c7f", endpointHostName: "https://qnaubsassist.azurewebsites.net/qnamaker")]
    public class AssistQuestionAnswerDialog : QnAMakerDialog
    {
		public AssistQuestionAnswerDialog()
		{
			WelcomeMessage = "Can I look for something for you in UBS Assist?";
		}

		protected override async Task DefaultWaitNextMessageAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
		{
			await context.PostAsync("Anything else?");
		}
	}
}