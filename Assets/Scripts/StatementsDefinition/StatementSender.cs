using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinCan;
using TinCan.LRSResponses;
using System;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.UI;
using System.IO;


//using UnityEditor.VersionControl;



public class StatementSender : MonoBehaviour
{
    //private RemoteLRS lrs;

    GameDefinitions gameDefinitions;
    //static Boolean isSlideCompleted = false;

    // Use this for initialization
    void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
       /* lrs = new RemoteLRS(
        "http://200.239.138.28:8080/xapi",
        "e9e46275f42b6af54f08d90c6392d2673b0e8f9aeddfee7b2818d5b77ef62551",
        "1b02723000f4b00c5b19b9ca7f3db2831af997fd488817e68786d27651ddce75"
        );*/
       
        
    }

    public void SendStament(string question, string answer, bool isCorrect, bool isComplete)
    {
        Debug.Log("call");
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/Logs/Player" + gameDefinitions.PLAYER + ".csv", true))
        {
            sw.WriteLine("Player: ; Player" + gameDefinitions.PLAYER.ToString() + "; Question: ;" + question + "; Answer: ;" + answer + "; isCorrect: ;" + isCorrect + "; isComplete: ;" + isComplete); ;
        }
        /*

        Agent actor = getActorByEmail("player" + gameDefinitions.PLAYER.ToString() + "@mestradorobson.com");
        
        //Build out Verb details

        TinCan.Verb verb = getVerb(LogVerb.Answered.url, LogVerb.Answered.descriptionEnUS);

        //Build out Activity details
        string extension = @"{'" + LogCategory.Question.url + "': {question: '" + question + "', answer: '" + answer + "'}}";
        Activity activity = getActivity(LogCategory.Question.url, LogCategory.Question.descriptionEnUS, extension);

        Result result = getResult(isComplete,
                                  isCorrect,
                                  isCorrect ? 100 : 0);

        StartCoroutine(SaveStatement(actor, verb, activity, result));*/
    }


    /*public async void logQuestionAnswers(string question, string answer, bool isCorrect) {
        Agent actor = getActorByEmail("player"+SetGameConfig.PLAYER.ToString()+"@testeusuario.com");

        //Build out Verb details
        TinCan.Verb verb = getVerb(LogVerb.Answered.url, LogVerb.Answered.descriptionEnUS);

        //Build out Activity details
        string extension = @"{'" + LogCategory.Question.url + "': {question: '"+ question +"', answer: '"+ answer + "'}}";
        Activity activity = getActivity(LogCategory.Question.url, LogCategory.Question.descriptionEnUS, extension);

        Result result = getResult(false, 
                                  isCorrect, 
                                  isCorrect ? 100 : 0);

        StartCoroutine(SaveStatement(actor, verb, activity, result));
    }

    public async void logQuizFinished() {

        Agent actor = getActor(UserLoginData.email);

        //Build out Verb details
        TinCan.Verb verb = getVerb(LogVerb.Completed.url, LogVerb.Completed.descriptionEnUS);

        //Build out Activity details
        Activity activity = getActivity(LogCategory.Assessment.url, LogCategory.Assessment.descriptionEnUS);

        Result result = getResult();

        StartCoroutine(SaveStatement(actor, verb, activity, result));
    }

    /*public async void logPassSlide() {
        Agent actor = getActor(UserLoginData.email);

        //Build out Verb details
        TinCan.Verb verb = getVerb(LogVerb.Viewed.url, LogVerb.Viewed.descriptionEnUS);

        //Build out Activity details
        Activity activity = getActivity(LogCategory.Slide.url, LogCategory.Slide.descriptionEnUS);

        Result result = getResult(SlideChange.isCompleted, 
                                  true, 
                                  SlideChange.slideAtual/Convert.ToDouble(SlideChange.totalNumberOfSliders)*100);

        StartCoroutine(SaveStatement(actor, verb, activity, result));
        if (isSlideCompleted == false && SlideChange.isCompleted == true) {
            isSlideCompleted = true;
            TinCan.Verb verbCompleted = getVerb(LogVerb.Completed.url, LogVerb.Completed.descriptionEnUS);

            Result resultCompleted = getResult(true, true, 100);
            print(isSlideCompleted);
            StartCoroutine(SaveStatement(actor, verbCompleted, activity, resultCompleted));
        }
    }

    IEnumerator SaveStatement(Agent actor,
                              TinCan.Verb verb, 
                              Activity activity, 
                              Result result) {

        //Build out full Statement details
        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.result = result;

        
        //Send the statement
        StatementLRSResponse lrsResponse = lrs.SaveStatement(statement);
        
        //Debug.Log(lrsResponse.httpException.ToString());
        

        if (lrsResponse.success) //Success
        {           
            Debug.Log("Save statement: " + lrsResponse.content.id);
        }
        else //Failure
        {
            
            Debug.Log("Statement Failed: " + lrsResponse.errMsg);
        }
        yield break;
    }

    Agent getActorByName(string actorName)
    {
        Agent actor = new Agent();
        actor.name = actorName;
        actor.openid = actorName;
        return actor;
    }

    Agent getActorByEmail(string email) {
        Agent actor = new Agent();
        actor.mbox = "mailto:" + email;
        actor.name = email.Split('@')[0];

        return actor;
    }

    TinCan.Verb getVerb(string verbURL, string description) {
        TinCan.Verb verb = new TinCan.Verb();
        verb.id = new Uri(verbURL);
        verb.display = new LanguageMap();
        verb.display.Add("en-US", description);

        return verb;
    }

    Activity getActivity(string activityURL, string description, string extensionString = "") {
        Activity activity = new Activity();
        activity.id = new Uri(activityURL).ToString();
        ActivityDefinition activityDefinition = new ActivityDefinition();
        activityDefinition.name = new LanguageMap();
        activityDefinition.name.Add("en-US", (description));
        if (extensionString != "") {
            TinCan.Extensions extension = new TinCan.Extensions(JObject.Parse(extensionString));
            activityDefinition.extensions = extension;
        }
        activity.definition = activityDefinition;
        return activity;
    }

    Result getResult(Boolean completion, Boolean success, Double raw) {
        Result result = new Result();
        result.completion= completion;
        result.success= success;
        Score score = new Score();
        score.raw = raw;
        result.score=score;

        return result;
    }*/


}