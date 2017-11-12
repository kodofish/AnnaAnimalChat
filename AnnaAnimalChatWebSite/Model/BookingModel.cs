using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace AnnaAnimalChatWebSite.Model
{
    public class BookingModel
    {
        public SelectList PetStatusSelectListItems => GetPetStatusSelectListItems();

        public SelectList PetAmountSelectListItems => GetPetAmountSelectListItems();

        public SelectList ChatSelectListItems => GetChatSelectListItems();

        public SelectList ChatTimeSelectListItems => GetChatTimeSelectListItems();

        public List<SelectListItem> TimePeriodSelectListItems => GetTimePeriodSelectListItems();

        [Required(ErrorMessage = "請輸入你的真實中文全名")]
        [Display(Name = "真實中文全名", Prompt = "浮水印?")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸你你的 LINE名稱/ID")]
        [Display(Name = "LINE名稱／ID")]
        public string LineId { get; set; }

        [Required(ErrorMessage = "請輸入你的自稱")]
        [Display(Name = "自稱")]
        public string NickName { get; set; }

        [Display(Name = "旁聽家人的全名")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "請輸入你的動物狀態")]
        [Display(Name = "動物狀態")]
        public int PetStatusId { get; set; }

        [Required(ErrorMessage = "請輸入動物數量")]
        [Display(Name = "動物數量")]
        public int PetAmount { get; set; }

        [Required(ErrorMessage = "請輸入動物名字或暱稱")]
        [Display(Name = "A動物名字或暱稱")]
        public string AnimalNameA { get; set; }

        [Required(ErrorMessage = "請上傳動物圖片")]
        public string PicA { get; set; }

        [Display(Name = "B動物名字或暱稱")]
        public string AnimalNameB { get; set; }

        [Required(ErrorMessage = "請上傳動物圖片")]
        public string PicB { get; set; }

        [Required(ErrorMessage = "請選擇聊天方式")]
        [Display(Name = "聊天方式")]
        public int Chat { get; set; }

        [Required(ErrorMessage = "請選擇聊天時間")]
        [Display(Name = "聊天時間")]
        public float Time { get; set; }

        public decimal Fee { get; private set; }

        [Required(ErrorMessage = "請選擇希望預約的時段")]
        [Display(Name = "希望預約的時段(可複選)")]

        public string TimePeriod { get; set; }

        private SelectList GetPetStatusSelectListItems()
        {
            var items = new List<PetStatusModel>
            {
                new PetStatusModel
                {
                    Id = 1,
                    Text = "在世"
                },
                new PetStatusModel
                {
                    Id = 2,
                    Text = "往生小天使+300"
                }
            };


            return new SelectList(items, "Id", "Text", PetStatusId);
        }

        private SelectList GetPetAmountSelectListItems()
        {
            var items = new List<PetAmountModel>
            {
                new PetAmountModel
                {
                    Id = 1,
                    Text = "1"
                },
                new PetAmountModel
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
                new ChatModel
                {
                    Id = 1,
                    Text = "LINE文字訊息"
                },
                new ChatModel
                {
                    Id = 2,
                    Text = "面對面"
                },
                new ChatModel
                {
                    Id = 3,
                    Text = "家訪"
                }
            };

            return new SelectList(items, "Id", "Text", Chat);
        }

        private SelectList GetChatTimeSelectListItems()
        {
            var items = new List<ChatTimeModel>
            {
                new ChatTimeModel
                {
                    Id = 1,
                    Value = 1,
                    Text = "1hr"
                },
                new ChatTimeModel
                {
                    Id = 2,
                    Value = 0.5f,
                    Text = "0.5hr"
                },
                new ChatTimeModel
                {
                    Id = 3,
                    Value = 1.5f,
                    Text = "1.5hr"
                }
            };

            return new SelectList(items, "Value", "Text", Time);
        }

        private List<SelectListItem> GetTimePeriodSelectListItems()
        {
            var timePeriods = GetAllTimePeriods();
            var items = new List<SelectListItem>();

            var selectedCategories = string.IsNullOrWhiteSpace(TimePeriod)
                ? null
                : TimePeriod.Split(',');

            foreach (var c in timePeriods)
                items.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Text,
                    Selected = selectedCategories?.Contains(c.Id.ToString()) ?? false
                });
            return items;
        }

        private IQueryable<TimePeriod> GetAllTimePeriods()
        {
            return new List<TimePeriod>
            {
                new TimePeriod
                {
                    Id = 1,
                    Text = "平日 下午12:00"
                },
                new TimePeriod
                {
                    Id = 2,
                    Text = "平日 下午14:30"
                },
                new TimePeriod
                {
                    Id = 3,
                    Text = "平日 晚上21:30"
                },
                new TimePeriod
                {
                    Id = 4,
                    Text = "假日 下午14:30"
                },
                new TimePeriod
                {
                    Id = 5,
                    Text = "假日 晚上21:30"
                }
            }.AsQueryable();
        }

        public void CalculateFee()
        {
            switch (Chat)
            {
                case 1:
                    switch (Time)
                    {
                        case 0.5f:
                            Fee = 600;
                            break;
                        case 1f:
                            Fee = 1000;
                            break;
                        case 1.5f:
                            Fee = 1300;
                            break;
                    }
                    break;
                case 2:
                    switch (Time)
                    {
                        case 1f:
                            Fee = 1200;
                            break;
                        case 1.5f:
                            Fee = 1500;
                            break;
                    }
                    break;
                case 3:
                    Fee = 2000;
                    break;
            }

            if (PetStatusId == 2 &&  Fee > 0)
                Fee += 300M;
        }
    }

    
}