namespace UI.State.Alphabet.Local
{
    public class ChallengeLocalState
    {
        public string ChallengeText { get; set; }
        public string ChallengeInputValue { get; set; }
        public string MyProperty { get; set; }
        public bool? Verdict { get; set; }
        public string Message { get; set; }
        public bool IsChallengeInProgress { get; set; }
        public bool IsGoDisabled { get; set; } = true;
        public bool IsNextDisabled { get; set; } = true;
        public Dictionary<string, int> Score { get; set; } = new()
        {
            {"Correct", 0 },
            {"Incorrect", 0 }
        };
    }
}