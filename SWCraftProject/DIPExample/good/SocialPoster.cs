/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;

namespace SWCraftProject.DIPExample.good
{
    public class SocialPoster
    {
        private readonly ISocialMedia mySocialMedia;

        public SocialPoster(ISocialMedia socialMedia)
        {
            mySocialMedia = socialMedia;
        }

        public void Post(Data data)
        {
            mySocialMedia.Post(data);
        }
    }

    public interface ISocialMedia
    {
        void Post(Data data);
    }

    public class Twitter : ISocialMedia
    {
        public void Post(Data data)
        {
            Console.WriteLine($"Posting: {data}");
        }
    }

    public class Facebook : ISocialMedia
    {
        public void Post(Data data)
        {
            Console.WriteLine($"Posting: {data}");
        }
    }

    public class Data
    {
        void abc()
        {
            var facebookPoster = new SocialPoster(new Facebook());
            facebookPoster.Post(this);
            var twitterPoster = new SocialPoster(new Twitter());
        }
    }
}