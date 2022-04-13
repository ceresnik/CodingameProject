/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
namespace SWCraftProject.DIPExample
{
    class SocialPoster
    {
        private readonly Twitter myTwitter;

        public SocialPoster(Twitter twitter)
        {
            myTwitter = twitter;
        }

        public void Post(Data data)
        {
            myTwitter.Post(data);
        }
    }

    internal class Twitter
    {
        public void Post(Data data) { }
    }

    internal class Data
    {
    }
}