using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MemberLog.Models;
using System;
using System.Linq;

namespace MemberLog.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MemberLogDBContext(
            serviceProvider.GetRequiredService<DbContextOptions<MemberLogDBContext>>()))
        {
            
            context.Members.AddRange(
                new Member
                {
                    member_pos_id="001",
                    member_code="001",
                    member_shop_id="001",
                    member_firstname="香り",
                    member_lastname = "Ashida",
                    member_firstname_kana="kaori",
                    member_lastname_kana="Ashida"
                    
                },
                new Member
                {
                    member_pos_id = "002",
                    member_code = "002",
                    member_shop_id = "002",
                    member_firstname = "香り",
                    member_lastname = "Ashida",
                    member_firstname_kana = "kaori",
                    member_lastname_kana = "Ashida"
                },
                new Member
                {
                    member_pos_id = "003",
                    member_code = "003",
                    member_shop_id = "002",
                    member_firstname = "香り",
                    member_lastname = "Ashida",
                    member_firstname_kana = "kaori",
                    member_lastname_kana = "Ashida"
                },
                new Member
                {
                    member_pos_id = "007",
                    member_code = "007",
                    member_shop_id = "007",
                    member_firstname = "香り",
                    member_lastname = "Ashida",
                    member_firstname_kana = "kaori",
                    member_lastname_kana = "Ashida"
                }
            );
            context.SaveChanges();
        }
    }
}