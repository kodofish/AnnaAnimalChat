using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using AnnaAnimalChatWebSite.Controllers;

namespace AnnaAnimalChatWebSite.Model
{
    public class BookingModel
    {
        private decimal _fee;
        public BookingModel()
        {
        }

        public SelectList PetStatusSelectListItems => GetPetStatusSelectListItems();

        public SelectList PetAmountSelectListItems => GetPetAmountSelectListItems();

        public SelectList ChatSelectListItems => GetChatSelectListItems();

        public SelectList ChatTimeSelectListItems => GetChatTimeSelectListItems();

        public List<SelectListItem> TimePeriodSelectListItems => GetTimePeriodSelectListItems();

        [Required]
        [Display(Name = "真實中文全名", Prompt = "浮水印?")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "LINE名稱／ID")]
        public string LineId { get; set; }
        [Required]
        [Display(Name = "自稱")]
        public string NickName { get; set; }
        [Display(Name = "旁聽家人的全名")]
        public string FamilyName { get; set; }
        [Required]
        [Display(Name = "動物狀態")]
        public int PetStatusId { get; set; }
        [Required]
        [Display(Name = "動物數量")]
        public int PetAmount { get; set; }
        [Required]
        [Display(Name = "A動物名字或暱稱")]
        public string AnimalNameA { get; set; }

        public string PicA { get; set; }
        [Display(Name = "B動物名字或暱稱")]
        public string AnimalNameB { get; set; }
        public string PicB { get; set; }
        [Required]
        [Display(Name = "聊天方式")]
        public int Chat { get; set; }
        [Required]
        [Display(Name = "聊天時間")]
        public float Time { get; set; }

        public decimal Fee => _fee;

        [Required]
        [Display(Name = "希望預約的時段(可複選)")]

        public string TimePeriod { get; set; }


        private SelectList GetPetStatusSelectListItems()
        {

            var items = new List<PetStatusModel>
            {
                new PetStatusModel()
                {
                    Id = 1,
                    Text = "在世",
                },
                new PetStatusModel()
                {
                    Id = 2,
                    Text = "往生小天使+300",
                }
            };


            return new SelectList(items, "Id", "Text", PetStatusId);
        }

        private SelectList GetPetAmountSelectListItems()
        {
            var items = new List<PetAmountModel>
            {
                new PetAmountModel()
                {
                    Id = 1,
                    Text = "1"
                },
                new PetAmountModel()
                {
                    Id = 2,
                    Text = "2"
                }
            };


            return new SelectList(items, "Id", "Text", PetAmount);
        }
        private SelectList GetChatSelectListItems()
        {
            var items = new List<ChatModel>
            {
                new ChatModel()
                {
                    Id = 1,
                    Text = "LINE文字訊息"
                },
                new ChatModel()
                {
                    Id = 2,
                    Text = "面對面"
                },
                new ChatModel()
                {
                    Id = 3,
                    Text = "家訪"
                }
            };

            return new SelectList(items, "Id", "Text", this.Chat);
        }

        private SelectList GetChatTimeSelectListItems()
        {
            var items = new List<ChatTimeModel>
            {
                new ChatTimeModel()
                {
                    Id = 1,
                    Value = 1,
                    Text = "1hr"
                },
                new ChatTimeModel()
                {
                    Id = 2,
                    Value = 0.5f,
                    Text = "0.5hr"
                },
                new ChatTimeModel()
                {
                    Id = 3,
                    Value = 1.5f,
                    Text = "1.5hr"
                }
            };

            return new SelectList(items, "Value", "Text", this.Time);
        }

        private List<SelectListItem> GetTimePeriodSelectListItems()
        {
            var timePeriods = GetAllTimePeriods();
            var items = new List<SelectListItem>();

            var selectedCategories = string.IsNullOrWhiteSpace(TimePeriod)
                ? null
                : TimePeriod.Split(',');

            foreach (var c in timePeriods)
            {
                items.Add( new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Text,
                    Selected = selectedCategories?.Contains(c.Id.ToString()) ?? false
                });
            }
            return items;
        }

        private IQueryable<TimePeriod> GetAllTimePeriods()
        {
            return new List<TimePeriod>()
            {
                new TimePeriod()
                {
                    Id = 1,
                    Text = "平日 下午12:00"
                },
                new TimePeriod()
                {
                    Id = 2,
                    Text = "平日 下午14:30"
                },
                new TimePeriod()
                {
                    Id = 3,
                    Text = "平日 晚上21:30"
                },
                new TimePeriod()
                {
                    Id = 4,
                    Text = "假日 下午14:30"
                },
                new TimePeriod()
                {
                    Id = 5,
                    Text = "假日 晚上21:30"
                },
            }.AsQueryable();
        }

        public void CalculateFee()
        {
            if (Chat == 1 && Time.Equals(0.5f))
                _fee = 600M;

            if (Chat == 1 && Time.Equals(1f))
                _fee = 1000;

            if (Chat == 1 && Time.Equals(1.5f))
                _fee = 1300;

            if (Chat == 3 && Time.Equals(1.5f))
                _fee = 2000;

            if (Chat == 2 && Time.Equals(1f))
                _fee = 1200;

            if (Chat == 2 && Time.Equals(1.5f))
                _fee = 1500;

            if (PetStatusId == 2)
                _fee += 300M;
        }
    }
}