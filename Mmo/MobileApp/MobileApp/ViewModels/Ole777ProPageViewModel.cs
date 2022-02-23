using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Views;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MobileApp.ViewModels
{
    public class Ole777ProPageViewModel : ViewModelBase
    {
        public List<BannerModel> Banners { get; set; } = new List<BannerModel>()
        {
            new BannerModel(){ImageName = "banner_1.jpg"},
            new BannerModel(){ImageName = "banner_2.jpg"},
            new BannerModel(){ImageName = "banner_3.jpg"},
            new BannerModel(){ImageName = "banner_4.jpg"},
            new BannerModel(){ImageName = "banner_5.jpg"},
            new BannerModel(){ImageName = "banner_6.jpg"},
        };

        public List<DanhMucGameModel> DanhMucGame { get; set; } = new List<DanhMucGameModel>()
        {
            new DanhMucGameModel()
            {
                ImageName = "icon_live_casino.png",
                Name = "Casino",
                Id = 0,
                DanhMucCon = new List<DanhMucConModel>()
            {
                    new DanhMucConModel()
                    {
                        ImageName = "icon_ag.png",
                        Name = "AG",
                        Id = 0,
                        Url = "https://m.ole777pro.com/player_center/goto_agingame/default/0",
                    },new DanhMucConModel()
                    {
                        ImageName = "icon_bbin.png",
                        Name = "BBIN",
                        Id = 1,
                        Url = "https://m.ole777pro.com/player_center/goto_bbin_game/live_dealer",
                    },new DanhMucConModel()
                    {
                        ImageName = "icon_bg_casino.png",
                        Name = "BG",
                        Id = 2,
                        Url = "https://m.ole777pro.com/player_center/goto_common_game/5874",
                    },new DanhMucConModel()
                    {
                        ImageName = "icon_dg.png",
                        Name = "DG",
                        Id = 3,
                        Url = "https://m.ole777pro.com/player_center/goto_dggame",
                    },
            }
            },
            new DanhMucGameModel(){ImageName = "icon_sportsbook.png",Name = "Thể Thao",Id = 1,DanhMucCon = new List<DanhMucConModel>()
            {
                new DanhMucConModel()
                {
                    ImageName = "icon_saba_sports.png",
                    Name = "SABA",
                    Id = 0,
                    Url = "https://m.ole777pro.com/player_center/goto_onebook_game/5839/null/null/false/blue1/",
                },new DanhMucConModel()
                {
                    ImageName = "icon_ole_sports_en.png",
                    Name = "77 Sports",
                    Id = 1,
                    Url = "https://m.ole777pro.com/iframe_module/goto_sbtech_bti_game",
                },new DanhMucConModel()
                {
                    ImageName = "icon_pinnacle.png",
                    Name = "Pinnacle",
                    Id = 2,
                    Url = "https://m.ole777pro.com/player_center/goto_pinnaclegame/sports",
                },new DanhMucConModel()
                {
                    ImageName = "icon_cmd.png",
                    Name = "CMD",
                    Id = 3,
                    Url = "https://m.ole777pro.com/player_center/goto_common_game/5765/",
                },new DanhMucConModel()
                {
                    ImageName = "icon_isaba_esports.png",
                    Name = "iSABA",
                    Id = 4,
                    Url = "https://m.ole777pro.com/player_center/goto_onebook_game/5839/null/null/true/blue1/",
                },
            }},
            new DanhMucGameModel(){ImageName = "icon_esports.png",Name = "E-Sports",Id = 2,DanhMucCon = new List<DanhMucConModel>()
            {
                new DanhMucConModel()
                {
                    ImageName = "icon_pinnacle.png",
                    Name = "Pinnacle",
                    Id = 0,
                    Url = "https://m.ole777pro.com/player_center/goto_pinnaclegame/e-sports",
                },new DanhMucConModel()
                {
                    ImageName = "icon_saba_esports.png",
                    Name = "SABA",
                    Id = 1,
                    Url = "https://m.ole777pro.com/player_center/goto_onebook_game/5839/esports/null/true/blue1/5/true",
                },new DanhMucConModel()
                {
                    ImageName = "icon_im2.png",
                    Name = "IM",
                    Id = 2,
                    Url = "https://m.ole777pro.com/iframe_module/goto_common_game/5840",
                },
            }},
            new DanhMucGameModel(){ImageName = "icon_slots.png",Name = "Nổ Hũ",Id = 3,DanhMucCon = new List<DanhMucConModel>()
            {
                new DanhMucConModel()
                {
                    ImageName = "icon_pp.png",
                    Name = "PP",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=pragmatic",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_onegame.png",
                    Name = "OG",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=onegame",
                }, new DanhMucConModel()
                {
                    ImageName = "gmt_icon.png",
                    Name = "GMT",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=gmt",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_rt.png",
                    Name = "RT",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=redtiger",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_tpg.png",
                    Name = "TPG",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=tpg_api",
                }, new DanhMucConModel()
                {
                    ImageName = "mob_playstar_logo.png",
                    Name = "PS",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=playstar",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_ae.png",
                    Name = "Ameba",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=ameba",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_jdb.png",
                    Name = "JDB",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=jumbo",
                }, new DanhMucConModel()
                {
                    ImageName = "icon_dtasia.png",
                    Name = "DT",
                    Id = 0,
                    Url = "https://m.ole777pro.com/slots.html?prv=dreamtech",
                },
            }},
            new DanhMucGameModel(){ImageName = "icon_poker.png",Name = "Game Bài",Id = 4,DanhMucCon = new List<DanhMucConModel>()
            {
                new DanhMucConModel()
                {
                    ImageName = "icon_km_new1.png",
                    Name = "Kingmaker",
                    Id = 0,
                    Url = "https://m.ole777pro.com/cards.html",
                },
            }},
            new DanhMucGameModel(){ImageName = "icon_lottery.png",Name = "Xổ Số",Id = 5,DanhMucCon = new List<DanhMucConModel>()
            {
                new DanhMucConModel()
                {
                    ImageName = "icon_gpi.png",
                    Name = "GPI",
                    Id = 0,
                    Url = "https://m.ole777pro.com/player_center/goto_gpgame/24/lottery_keno/null/keno/0",
                },
            }},
        };
        private DelegateCommand<DanhMucGameModel> _chonDanhMucCommand;
        private ObservableCollection<DanhMucConModel> _danhMucCons = new ObservableCollection<DanhMucConModel>(new List<DanhMucConModel>()
        {
            new DanhMucConModel()
            {
                ImageName = "icon_ag.png",
                Name = "AG",
                Id = 0,
                Url = "https://m.ole777pro.com/player_center/goto_agingame/default/0",
            },
            new DanhMucConModel()
            {
                ImageName = "icon_bbin.png",
                Name = "BBIN",
                Id = 1,
                Url = "https://m.ole777pro.com/player_center/goto_bbin_game/live_dealer",
            },
            new DanhMucConModel()
            {
                ImageName = "icon_bg_casino.png",
                Name = "BG",
                Id = 2,
                Url = "https://m.ole777pro.com/player_center/goto_common_game/5874",
            },
            new DanhMucConModel()
            {
                ImageName = "icon_dg.png",
                Name = "DG",
                Id = 3,
                Url = "https://m.ole777pro.com/player_center/goto_dggame",
            },
        });

        public DelegateCommand<DanhMucGameModel> ChonDanhMucCommand =>
            _chonDanhMucCommand ?? (_chonDanhMucCommand = new DelegateCommand<DanhMucGameModel>((item) => ExecuteChonDanhMucCommand(item)));

        public ObservableCollection<DanhMucConModel> DanhMucCons
        {
            get => _danhMucCons;
            set => SetProperty(ref _danhMucCons, value);
        }

        public ICommand ChonDanhMucConCommand { get; private set; }
        public ICommand ChonChucNang { get; private set; }
        public Ole777ProPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ChonDanhMucConCommand = new AsyncCommand<DanhMucConModel>((obj) => ExecuteChonDanhMucConCommand(obj));
            ChonChucNang = new AsyncCommand<string>((key) => ExecuteChonChucNang(key));
        }

        private Task ExecuteChonChucNang(string key)
        {
            var para = new NavigationParameters();
            switch (key)
            {
                case "0":
                    para.Add("title", "Đăng nhập");
                    para.Add("url", "https://player.ole777pro.com/iframe/auth/login");
                    break;
                case "1":
                    para.Add("title", "Đăng ký");
                    para.Add("url", "https://player.ole777pro.com/player_center/iframe_register");
                    break;
                case "2":
                    para.Add("title", "Khuyến Mãi");
                    para.Add("url", "https://m.ole777pro.com/promotions.html");
                    break;
                case "3":
                    para.Add("title", "Dịch vụ");
                    para.Add("url", "https://im.haoli01.com/chat/text/chat_09V9o8.html?skill=2c9285b3753ec4cb0175bb2199735273&l=vi");
                    break;
                case "4":
                    para.Add("title", "Nạp Tiền");
                    para.Add("url", "https://player.ole777pro.com/player_center2/deposit");
                    break;
                case "5":
                    para.Add("title", "Trung Tâm Người Chơi");
                    para.Add("url", "https://player.ole777pro.com/player_center/menu");
                    break;
                default:
                    para.Add("title", "Trang chủ");
                    para.Add("url", "https://m.ole777pro.com/");
                    break;
            }

            return NavigationService.NavigateAsync(nameof(WebviewPage), para);
        }

        private Task ExecuteChonDanhMucConCommand(DanhMucConModel danhMucConModel)
        {
            var para = new NavigationParameters();
            para.Add("title", danhMucConModel.Name);
            para.Add("url", danhMucConModel.Url);
            return NavigationService.NavigateAsync(nameof(WebviewPage), para);
        }

        void ExecuteChonDanhMucCommand(DanhMucGameModel danhMucGame)
        {
            DanhMucCons = new ObservableCollection<DanhMucConModel>(danhMucGame.DanhMucCon);
        }
    }

    public class DanhMucGameModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }
        public List<DanhMucConModel> DanhMucCon { get; set; }
    }

    public class DanhMucConModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class BannerModel
    {
        public string ImageName { get; set; }
    }
}
