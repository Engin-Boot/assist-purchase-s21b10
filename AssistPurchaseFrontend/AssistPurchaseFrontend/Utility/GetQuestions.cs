using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace AssistPurchaseFrontend.Utility
{
    class GetQuestions
    {
        public static RequestResponse question = new RequestResponse();
        private static RequestResponse old_question = new RequestResponse();
        public static string choicesMade = "";
        public QuestionBlock getQuestion()
        {
            QuestionBlock block = new QuestionBlock();
            if (question.Layer == "lastLayer")
            {
                block.Choice_Question.Text = "Are you sure about the options?? Choose Yes/No..!!";
                AddChoices(new string[] { "Yes", "No" }, block);
            }
            else
            {
                block.Choice_Question.Text = "Choose " + question.Layer + " from ";
                AddChoices(question.LayerMembers, block);
            }
            return block;
        }
        public void setPreviousQuestion()
        {
            old_question.ChoiceDictionary.Remove(old_question.Layer);
            question = old_question;
        }

        public void AddChoices(string[] layerMembers,QuestionBlock block)
        {
            for (int i = 0; i < layerMembers.Length; i++)
            {
                ToggleButton b1 = new ToggleButton();
                b1.Content = layerMembers[i];
                b1.Style =(Style) Application.Current.Resources["ToggleButtonStyle"];
                b1.Checked += B1_Checked;
                b1.Unchecked += B1_Unchecked;
                block.ChoiceOptions.Children.Add(b1);
            }
        }

        private void B1_Unchecked(object sender, RoutedEventArgs e)
        {
            string buttonText = ((ToggleButton)sender).Content.ToString();
            choicesMade = choicesMade.Replace(buttonText +",","");
        }

        private void B1_Checked(object sender, RoutedEventArgs e)
        {
            string buttonText = ((ToggleButton)sender).Content.ToString();
            choicesMade += buttonText + ",";
        }

        public async Task getNextQuestions(string[] choices)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            old_question = question;
            question.ChoiceDictionary.Add(question.Layer, choices);
            var json = JsonConvert.SerializeObject(question);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/product/questions", data);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                question = JsonConvert.DeserializeObject<RequestResponse>(jsonContent);
                choicesMade = "";
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public async Task<QuestionBlock> Question()
        {
            string[] choices = choicesMade.Split(',');
            await getNextQuestions(choices);
            QuestionBlock block = getQuestion();
            return block;
        }
    }
}
