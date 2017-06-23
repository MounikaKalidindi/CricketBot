using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Crick_Bot
{
    [LuisModel("acdc813f-bdd9-41b9-9e20-48a109895794", "462a135179eb4b229bd05bb2e18faf9c")]
    [Serializable]
    public class Crick_Luis : LuisDialog<object>
    {
        /* public string message;
         public Crickbot()
         {
             string message;
             this.message = message;
         }*/
        [LuisIntent("start_convo")]
        public async Task Start_convo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hai");
            await context.PostAsync("I am Crick Bot " + Environment.NewLine + Environment.NewLine + "I can give you the details of Recent/Live cricket matches " + Environment.NewLine + Environment.NewLine + " and daily top news..");
            //CarouselCardsDialog ccd = new CarouselCardsDialog();
            var reply = context.MakeMessage();


            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            await context.PostAsync("TODAY'S TOP NEWS..");
            reply.Attachments = Top_GetCardsAttachments();
            await context.PostAsync(reply);

            //context.Wait(this.MessageReceivedAsync);
            //httpReqResc res = new httpReqResc();
            //string res_topnews = res.MakeRequest();
            //RootObject ro = JsonConvert.DeserializeObject<RootObject>(res_topnews);
            // RootObject ro = JsonConvert.DeserializeObject<RootObject>(res_topnews);
            // foreach (var v in ro.articles)
            //{
            //String auth = "Author" + ro.articles[0].author;
            //Uri uri = new Uri(ro.articles[0].url);
            // foreach(var v in ro.articles) { 
            // return new List<Attachment>()
            //{//foreach (var v in ro.articles) {
            //ccd.GetHeroCard();

            //}//Crick_luis crick = new Crick_luis();
            // await context.PostAsync("Haii....");
            context.Wait(MessageReceived);
        }
        [LuisIntent("about")]
        public async Task About(IDialogContext context, LuisResult result)
        {
            Crick_Luis crick = new Crick_Luis();
            await context.PostAsync("I am crick bot i can give you details of cricket matches and top news regarding the cricket matches..");
            context.Wait(MessageReceived);
        }
        [LuisIntent("who_won_toss")]
        public async Task Who_won_toss(IDialogContext context, LuisResult result)
        {
            Crick_Luis crick = new Crick_Luis();
            await context.PostAsync(".....won the toss");
            context.Wait(MessageReceived);
        }
        [LuisIntent("opening_players")]
        public async Task Opening_players(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....are the opening players");
            context.Wait(MessageReceived);
        }
        [LuisIntent("current_batting_players")]
        public async Task Current_batting_players(IDialogContext context, LuisResult result)
        {

            await context.PostAsync("....are the players batting now.");
            context.Wait(MessageReceived);
        }
        [LuisIntent("current_bowling_player")]
        public async Task Current_bowling_players(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is bowling now.");
            context.Wait(MessageReceived);
        }
        [LuisIntent("highest_scored_player_batting")]
        public async Task highest_scored_player_batting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the one who scored highest");
            context.Wait(MessageReceived);
        }
        [LuisIntent("highest_wickets_drawn_bowler")]
        public async Task highest_wickets_drawn_bowler(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the one who scored highest");
            context.Wait(MessageReceived);
        }
        [LuisIntent("man_of_the_match")]
        public async Task Man_of_the_match(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is man of the match");
            context.Wait(MessageReceived);
        }
        [LuisIntent("match_summary")]
        public async Task Match_summary(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("here is the summary of the match");
            context.Wait(MessageReceived);
        }
        [LuisIntent("place_of_match")]
        public async Task Place_of_match(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the one who scored highest");
            context.Wait(MessageReceived);
        }
        [LuisIntent("batsman_strike_rate")]
        public async Task Batsman_strike_rate(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the strike rate");
            context.Wait(MessageReceived);
        }
        [LuisIntent("batsman_score")]
        public async Task Batsman_score(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the strike rate");
            context.Wait(MessageReceived);
        }
        [LuisIntent("who_won_match")]
        public async Task Who_won_match(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....won the match");
            context.Wait(MessageReceived);
        }
        [LuisIntent("no.of_six_player")]
        public async Task No_of_six_player(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....sixes by the player");
            context.Wait(MessageReceived);
        }
        [LuisIntent("no.of_six_team")]
        public async Task No_of_six_team(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("...are the total no.of 6's by the team");
            context.Wait(MessageReceived);
        }
        [LuisIntent("no.of_four_player")]
        public async Task No_of_four_player(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....fours by the player");
            context.Wait(MessageReceived);
        }
        [LuisIntent("no.of_four_team")]
        public async Task No_of_four_team(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("...aral no.of the 4's by the team");
            context.Wait(MessageReceived);
        }
        [LuisIntent("final_team_score")]
        public async Task Final_score(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....is the total score");
            context.Wait(MessageReceived);
        }
        [LuisIntent("total_wickets_down")]
        public async Task Wickets_down(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....wickets down");
            context.Wait(MessageReceived);
        }
        [LuisIntent("extras")]
        public async Task Extras(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("....are extras");
            context.Wait(MessageReceived);
        }

        [LuisIntent("end_convo")]
        public async Task End_convo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("bye!!");
            context.Wait(MessageReceived);
        }
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry!!" + Environment.NewLine + Environment.NewLine + "I did'nt get you..." + Environment.NewLine + Environment.NewLine + "Try asking me different queries..");
            context.Wait(MessageReceived);
        }
        public class Article
        {
            public string author { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string urlToImage { get; set; }
            public string publishedAt { get; set; }
        }
        private class RootObject
        {

            public string status { get; set; }
            public string source { get; set; }
            public string sortBy { get; set; }
            public List<Article> articles { get; set; }
        }
        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }
        private static IList<Attachment> Top_GetCardsAttachments()
        {
            HttpReqRes res = new HttpReqRes();
            string res_topnews = res.MakeRequest();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(res_topnews);
            // foreach (var v in ro.articles)
            //{
            String auth = "Author" + ro.articles[0].author;
            //Uri uri = new Uri(ro.articles[0].url);
            // foreach(var v in ro.articles) { 
            return new List<Attachment>()
            {//foreach (var v in ro.articles) {
                
                GetHeroCard(
                      ro.articles[0].title,
                      auth,
                      ro.articles[0].description,
                     new CardImage(url: ro.articles[0].urlToImage),
                     new CardAction(ActionTypes.OpenUrl, "Learn more", value:ro.articles[0].url)),
             GetHeroCard(
                     ro.articles[1].title,
                     auth,
                     ro.articles[1].description,
                    new CardImage(url: ro.articles[1].urlToImage),
                    new CardAction(ActionTypes.OpenUrl, "Learn more", value: ro.articles[1].url)),
             GetHeroCard(
                      ro.articles[2].title,
                      auth,
                      ro.articles[2].description,
                     new CardImage(url: ro.articles[2].urlToImage),
                     new CardAction(ActionTypes.OpenUrl, "Learn more", value:ro.articles[2].url)),
             GetHeroCard(
                      ro.articles[3].title,
                      auth,
                      ro.articles[3].description,
                     new CardImage(url: ro.articles[3].urlToImage),
                     new CardAction(ActionTypes.OpenUrl, "Learn more", value:ro.articles[3].url)),
             GetHeroCard(
                      ro.articles[4].title,
                      auth,
                      ro.articles[4].description,
                     new CardImage(url: ro.articles[4].urlToImage),
                     new CardAction(ActionTypes.OpenUrl, "Learn more", value:ro.articles[4].url)),
                 };
        }


    }

}