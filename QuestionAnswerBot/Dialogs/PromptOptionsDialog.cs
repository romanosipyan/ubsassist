using Haskathon.QuestionAnswerBot.Controllers.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haskathon.QuestionAnswerBot.Dialogs
{
	[Serializable]
	//This is actually Root Dialog of this bot, but I named PromptButtons Dialog becuase I want to set similar name in node.js sample.
	public class PromptButtonsDialog : IDialog<object>
	{
		private const string AssistOption = "UBS Assist";
		private const string AccountDetailsOption = "Account details";

		public async Task StartAsync(IDialogContext context)
		{
			context.Wait(this.MessageRecievedAsync);
		}

		public virtual async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
		{
			//Show options whatever users chat
			PromptDialog.Choice(context, this.AfterMenuSelection, new List<string>() { AssistOption, AccountDetailsOption }, "What kind of information do you need?");
		}

		//After users select option, Bot call other dialogs
		private async Task AfterMenuSelection(IDialogContext context, IAwaitable<string> result)
		{
			var optionSelected = await result;
			switch (optionSelected)
			{
				case AssistOption:
					context.Call(new SimpleQuestionAnswerDialog(), ResumeAfterOptionDialog);
					break;
				case AccountDetailsOption:
					context.Call(new SimpleQuestionAnswerDialog(), ResumeAfterOptionDialog);
					break;
			}

		}

		//This function is called after each dialog process is done
		private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
		{
			//This means  MessageRecievedAsync function of this dialog (PromptButtonsDialog) will receive users' messeges
			context.Wait(MessageRecievedAsync);
		}
	}
}