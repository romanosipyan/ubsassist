using Haskathon.QuestionAnswerBot.Controllers.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haskathon.QuestionAnswerBot.Dialogs
{
	[Serializable]
	public class PromptButtonsDialog : IDialog<object>
	{
		private const string AssistOption = "UBS Assist";
		private const string AccountDetailsOption = "Account details";

		public async Task StartAsync(IDialogContext context)
		{
			context.Wait(MessageRecievedAsync);
		}

		public virtual async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
		{
			PromptDialog.Choice(context, AfterMenuSelection, new List<string>() { AssistOption, AccountDetailsOption }, "What kind of information do you need?");
		}

		private async Task AfterMenuSelection(IDialogContext context, IAwaitable<string> result)
		{
			var optionSelected = await result;
			switch (optionSelected)
			{
				case AssistOption:
					context.Call(new AssistQuestionAnswerDialog(), ResumeAfterOptionDialog);
					break;
				case AccountDetailsOption:
					context.Call(new AccountDataQuestionAnswerDialog(), ResumeAfterOptionDialog);
					break;
			}

		}

		private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
		{
			context.Wait(MessageRecievedAsync);
		}
	}
}