/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;

namespace SWCraftProject.DIPExample.good
{
    public class SocialPoster
    {
        private readonly ISocialPoster mySocialMedia;

        public SocialPoster(ISocialPoster socialMedia)
        {
            mySocialMedia = socialMedia;
        }

        public void Post(Data data)
        {
            mySocialMedia.Post(data);
        }
    }

    public interface ISocialPoster
    {
        void Post(Data data);
    }

    public class Twitter : ISocialPoster
    {
        public void Post(Data data)
        {
            Console.WriteLine($"Posting: {data}");
        }
    }

    public class Facebook : ISocialPoster
    {
        public void Post(Data data)
        {
            Console.WriteLine($"Posting: {data}");
        }
    }

    public class Data
    {
    }
}