namespace UI.State.Phrase.Actions
{
    public class UpdatePhraseChallengeAction
    {
        public List<string> Changed { get; set; }
        public string ChallengeText { get; set; }
        public string ChallengeInputValue { get; set; }
        public bool? Verdict { get; set; }
        public string Message { get; set; }
        public bool IsChallengeInProgress { get; set; }
        public bool IsGoDisabled { get; set; } = true;
        public bool IsNextDisabled { get; set; } = true;
        public bool IncrementScore { get; set; }
        public bool DecrementScore { get; set; }
        public bool ResetScore { get; set; }
        public Dictionary<string, int> Score { get; set; } = new()
        {
            {"Correct", 0 },
            {"Incorrect", 0 }
        };
    }
}
