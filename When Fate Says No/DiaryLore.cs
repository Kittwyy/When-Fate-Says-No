using System.Collections.Generic;

public static class DiaryLore
{
    // Diese Methode gibt eine Liste mit allen vordefinierten Tagebucheinträgen zurück.
    public static List<string> GetPrewrittenEntries()
    {
        List<string> entries = new List<string>
        {
            "April 14th.\nAnother day the same as the last. The sun came up. I wish it hadn't.",
            "May 2nd.\nSaw Mrs. Gable next door watering her plastic flowers again. We're not so different, her and I.",
            "May 19th.\nI found a photograph of me as a child today. I was smiling. I don't remember what that felt like. Who was that person?",
            "June 3rd.\nFate is not a grand, operatic force. It's the dull, grinding weight of a thousand tiny coincidences, all conspiring to keep you exactly where you are."
        };

        return entries;
    }
}