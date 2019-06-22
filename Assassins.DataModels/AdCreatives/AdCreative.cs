using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.AdImages;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.Creatives
{
    public class AdCreative : IDataModel, IHistoryData
    {
        public DateTime DateRecorded { get; set; }
        public long AppUserDataSyncId { get; set; }
        public virtual AppUserDataSync AppUserDataSync { get; set; }

        public long id { get; set; }
        public long account_id { get; set; }
        public virtual AdAccount AdAccount { get; set; }
        public string body { get; set; }
        public string call_to_action_type { get; set; }
        public string effective_object_story_id { get; set; }
        public string image_hash { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string adimage_id { get; set; }
        public virtual AdImage AdImage { get; set; }
        public long? effective_instagram_story_id { get; set; }
        public long? instagram_actor_id { get; set; }
        public string instagram_permalink_url { get; set; }
        public long? instagram_story_id { get; set; }
        public long? link_og_id { get; set; }
        public string link_url { get; set; }
        public string messenger_sponsored_message { get; set; }
        public long? object_id { get; set; }
        public string object_story_id { get; set; }
        public string object_type { get; set; }
        public string object_url { get; set; }
        public string status { get; set; }
        public string template_url { get; set; }
        public string thumbnail_url { get; set; }
        public string title { get; set; }
        public string url_tags { get; set; }
        public long? video_id { get; set; }


        public override IDataViewModel ToViewModel()
        {
            var model = new AdCreativeViewModel()
            {
                id = id,
                adimage_id = adimage_id,
                call_to_action_type = call_to_action_type,
                body = body,
                effective_object_story_id = effective_object_story_id,
                image_hash = image_hash,
                image_url = image_url,
                name = name,
                account_id = account_id,
                effective_instagram_story_id = effective_instagram_story_id,
                instagram_actor_id = instagram_actor_id,
                instagram_permalink_url = instagram_permalink_url,
                instagram_story_id = instagram_story_id,
                link_og_id = link_og_id,
                link_url = link_url,
                messenger_sponsored_message = messenger_sponsored_message,
                object_id = object_id,
                object_story_id = object_story_id,
                object_type = object_type,
                object_url = object_url,
                status = status,
                template_url = template_url,
                thumbnail_url = thumbnail_url,
                title = title,
                url_tags = url_tags,
                video_id = video_id
            };

            return model;
        }
    }
    public class AdCreativeViewModel : IDataViewModel
    {
        public long id { get; set; }
        public long account_id { get; set; }
        public string body { get; set; }
        public string call_to_action_type { get; set; }
        public string effective_object_story_id { get; set; }
        public string image_hash { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string adimage_id { get; set; }
        public long? effective_instagram_story_id { get; set; }
        public long? instagram_actor_id { get; set; }
        public string instagram_permalink_url { get; set; }
        public long? instagram_story_id { get; set; }
        public long? link_og_id { get; set; }
        public string link_url { get; set; }
        public string messenger_sponsored_message { get; set; }
        public long? object_id { get; set; }
        public string object_story_id { get; set; }
        public string object_type { get; set; }
        public string object_url { get; set; }
        public string status { get; set; }
        public string template_url { get; set; }
        public string thumbnail_url { get; set; }
        public string title { get; set; }
        public string url_tags { get; set; }
        public long? video_id { get; set; }
        public IDataModel ToModel()
        {
            var vm = new AdCreative()
            {
                adimage_id = adimage_id,
                call_to_action_type = call_to_action_type,
                body = body,
                effective_object_story_id = effective_object_story_id,
                image_hash = image_hash,
                image_url = image_url,
                name = name,
                account_id = account_id,
                effective_instagram_story_id = effective_instagram_story_id,
                instagram_actor_id = instagram_actor_id,
                instagram_permalink_url = instagram_permalink_url,
                instagram_story_id = instagram_story_id,
                link_og_id = link_og_id,
                link_url = link_url,
                messenger_sponsored_message = messenger_sponsored_message,
                object_id = object_id,
                object_story_id = object_story_id,
                object_type = object_type,
                object_url = object_url,
                status = status,
                template_url = template_url,
                thumbnail_url = thumbnail_url,
                title = title,
                url_tags = url_tags,
                video_id = video_id
            };

            return vm;
        }
    }
}
