using System;
using Newtonsoft.Json.Linq;
using Worklight;

namespace AccenturePeoplePCL.MobileFirst.Seguridad
{
	public delegate void EventSuccessHandler(JObject identity);

	public class SecurityChallengeHandler : SecurityCheckChallengeHandler
	{
		private bool shouldSubmitAnswer = false;

		private JObject ChallengeAnswer { get; set; }

		public event EventSuccessHandler eventSuccessHandler;

		public SecurityChallengeHandler(string realm, JObject challengeAnswer)
		{
			//Realm = security method.
			this.SecurityCheck = realm;
			this.ChallengeAnswer = challengeAnswer;
		}

		public override string SecurityCheck { get; set; }

		public override JObject GetChallengeAnswer()
		{
			return this.ChallengeAnswer;
		}

		public override void HandleChallenge(object challenge)
		{
			shouldSubmitAnswer = true;
		}

		public override void HandleFailure(JObject error)
		{
			//throw new Exception("Challenge error");
		}

		public override void HandleSuccess(JObject identity)
		{
			shouldSubmitAnswer = false;
			this.eventSuccessHandler(identity);
		}

		public override bool ShouldSubmitChallengeAnswer()
		{
			return shouldSubmitAnswer;
		}

	}
}
