using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Config
{
    public class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.PhoneID);
            builder.Property(p => p.PhoneName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PhoneSlug).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PhoneCode).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Phone
                {
                    PhoneID = 1,
                    BrandID = 1,
                    PhoneName = "iPhone 15",
                    PhoneSlug = "iphone-15",
                    PhoneCode = "APL-I15",
                    PhonePhotoUrl = "/img/iphone-15.png",
                    PhoneDetail = "DYNAMIC ISLAND COMES TO IPHONE 15 ...",
                    PhoneStock = 100,
                    PhonePrice = 799,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 2,
                    BrandID = 1,
                    PhoneName = "iPhone 15 Pro",
                    PhoneSlug = "iphone-15-pro",
                    PhoneCode = "APL-15P",
                    PhonePhotoUrl = "/img/iphone-15-pro.png",
                    PhoneDetail = "FORGED IN TITANIUM — iPhone 15 Pro Max has a strong and light aerospace-grade titanium design...",
                    PhoneStock = 50,
                    PhonePrice = 999,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 3,
                    BrandID = 1,
                    PhoneName = "iPhone 14",
                    PhoneSlug = "iphone-14",
                    PhoneCode = "APL-I14",
                    PhonePhotoUrl = "/img/iphone-14.png",
                    PhoneDetail = "6.1-inch Super Retina XDR display2  • Advanced camera system for better photos in any light ...",
                    PhoneStock = 80,
                    PhonePrice = 699,
                    PhoneOldPrice = 899,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 4,
                    BrandID = 1,
                    PhoneName = "iPhone 14 Plus",
                    PhoneSlug = "iphone-14-plus",
                    PhoneCode = "APL-14P",
                    PhonePhotoUrl = "/img/iphone-14-plus.png",
                    PhoneDetail = "6.7-inch Super Retina XDR display1  • Advanced camera system for better photos in any light ...",
                    PhoneStock = 200,
                    PhonePrice = 799,
                    PhoneOldPrice = 999,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 5,
                    BrandID = 1,
                    PhoneName = "iPhone SE",
                    PhoneSlug = "iphone-se",
                    PhoneCode = "APL-ISE",
                    PhonePhotoUrl = "/img/iphone-se.png",
                    PhoneDetail = "4.7-inch Retina HD display1  • Advanced single-camera system with 12MP Wide camera; Smart HDR 4, Photographic Styles, Portrait mode and 4K video up to 60 fps ...",
                    PhoneStock = 99,
                    PhonePrice = 579,
                    PhoneOldPrice = 669,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 6,
                    BrandID = 1,
                    PhoneName = "iPhone 13",
                    PhoneSlug = "iphone-13",
                    PhoneCode = "APL-I13",
                    PhonePhotoUrl = "/img/iphone-13.png",
                    PhoneDetail = "6.1-inch Super Retina XDR display2  • Cinematic mode adds shallow depth of field and shifts focus automatically in your videos ...",
                    PhoneStock = 10,
                    PhonePrice = 899,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 7,
                    BrandID = 2,
                    PhoneName = "SAMSUNG Galaxy S23 FE 5G - 128 GB, Purple",
                    PhoneSlug = "samsung-galaxy-s23-fe-5g---128-gb-purple",
                    PhoneCode = "SMG-S23",
                    PhonePhotoUrl = "/img/samsung-galaxy-s23-fe-5g---128-gb-purple.webp",
                    PhoneDetail = "Android 13  6.4\" Full HD+ Super AMOLED touchscreen  Triple 50 MP / 12 MP / 8 MP main cameras ...",
                    PhoneStock = 10,
                    PhonePrice = 599,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 8,
                    BrandID = 2,
                    PhoneName = "SAMSUNG Galaxy A14 - 64 GB, Black",
                    PhoneSlug = "samsung-galaxy-a14---64-gb-black",
                    PhoneCode = "SMG-A14",
                    PhonePhotoUrl = "/img/samsung-galaxy-a14---64-gb-black.webp",
                    PhoneDetail = "Android 13  6.6\" Full HD+ LCD touchscreen  Triple 50 MP / 5 MP / 2 MP main cameras ...",
                    PhoneStock = 20,
                    PhonePrice = 149,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 9,
                    BrandID = 2,
                    PhoneName = "SAMSUNG Galaxy A34 5G - 128 GB, Awesome Black",
                    PhoneSlug = "samsung-galaxy-a34-5g---128-gb-awesome-black",
                    PhoneCode = "SMG-A34",
                    PhonePhotoUrl = "/img/samsung-galaxy-a34-5g---128-gb-awesome-black.webp",
                    PhoneDetail = "Android 13  6.6\" Full HD+ Super AMOLED touchscreen  Triple 48 MP / 8 MP / 5 MP main cameras ...",
                    PhoneStock = 40,
                    PhonePrice = 349,
                    PhoneOldPrice = 0,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 10,
                    BrandID = 3,
                    PhoneName = "HUAWEI P20 Pro 128 GB/6 GB Single SIM Smartphone - Twilight (United Kingdom Version)",
                    PhoneSlug = "huawei-p20-pro-128-gb6-gb-single-sim-smartphone---twilight-united-kingdom-version",
                    PhoneCode = "HUA-20P",
                    PhonePhotoUrl = "/img/huawei-p20-pro-128-gb6-gb-single-sim-smartphone---twilight-united-kingdom-version.jpg",
                    PhoneDetail = "About this item Huawei 51092NWK Color: twilight",
                    PhoneStock = 5,
                    PhonePrice = 149,
                    PhoneOldPrice = 359,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                },
                new Phone
                {
                    PhoneID = 11,
                    BrandID = 4,
                    PhoneName = "Xiaomi Redmi Note 12 Smartphone, 4+128GB, 6.67 Inch FHD+ AMOLED DotDisplay, 5,000 mAh, 50MP Camera",
                    PhoneSlug = "xiaomi-redmi-note-12-smartphone-4128gb-667-inch-fhd-amoled-dotdisplay-5000-mah-50mp-camera",
                    PhoneCode = "XOI-N12",
                    PhonePhotoUrl = "/img/xiaomi-redmi-note-12-smartphone-4128gb-667-inch-fhd-amoled-dotdisplay-5000-mah-50mp-camera.jpg",
                    PhoneDetail = "About this item High resolution display: perfect readability in the sun, smooth scrolling, smooth videos and animations thanks to 120Hz refresh rate and 2400 x 1080 pixels Reliable performance: short response times even with complex applications, fast charging times and smooth gaming - possible with the built-in Snapdragon 685 High-resolution camera system: whether selfies with 13MP or with 50MP colourful photos and videos, the 50MP camera system allows high-resolution shots in any situation Long battery life: the 5000 mAh strong battery lasts all day and longer - the 33 W fast charging system allows for rapid charging of the Redmi mobile phone Handy design: the Redmi mobile phone combines high performance with a modern and slim design - height: 165.66 mm, width: 75.96 mm, depth: 7.85 mm, weight: 183.5 g",
                    PhoneStock = 25,
                    PhonePrice = 149,
                    PhoneOldPrice = 259,
                    PhoneRating = 0,
                    PhoneRatingCountUser = 0,
                    PhoneStar = 0,
                    PhoneOnSale = true,
                    PhoneIsActive = true
                }
            );
        }
    }
}
