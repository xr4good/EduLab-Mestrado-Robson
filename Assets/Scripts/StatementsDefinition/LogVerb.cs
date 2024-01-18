public struct Verb
{
    public string url;
    public string descriptionEnUS;
    public string descriptionPtBR;

    public Verb(string url, string descriptionEnUS, string descriptionPtBR)
    {
        this.url = url;
        this.descriptionEnUS = descriptionEnUS;
        this.descriptionPtBR = descriptionPtBR;
    }
}


public class LogVerb
{

    public static Verb Viewed   { get { return new Verb("http://id.tincan.com/verb/viewed", "viewed", "visualizou"); } }
    public static Verb Completed   { get { return new Verb("http://adlnet.gov/expapi/verbs/completed", "completed", "completou"); } }
    public static Verb Answered   { get { return new Verb("http://adlnet.gov/expapi/verbs/answered", "answered", "respondeu"); } }
    
    public static Verb ArrivedAt { get { return new Verb("https://xapi.percipio.com/xapi/verbs/arrived", "arrived at", "chegou"); } }

    public static Verb Passed { get { return new Verb("http://adlnet.gov/expapi/verbs/passed", "passed", "passou"); } }

    public static Verb Failed { get { return new Verb("http://adlnet.gov/expapi/verbs/failed", "failed", "fracassou"); } }

    public static Verb Scored { get { return new Verb("https://w3id.org/xapi/dod-isd/verbs/scored", "scored", "pontuou"); } }

    public static Verb Inicialized { get { return new Verb("http://adlnet.gov/expapi/verbs/initialized", "initialized", "iniciou"); } }




}