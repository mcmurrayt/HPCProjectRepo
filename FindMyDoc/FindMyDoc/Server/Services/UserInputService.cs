using FindMyDoc.Server.Data;
using FindMyDoc.Server.Models;
using FindMyDoc.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindMyDoc.Server.Services
{
    public class UserInputService
    {
        public async Task<int> GetProviderNum(bool nurse, bool physician, bool physician_Assistant)
        {
            int sum = 0;
            if (nurse == true)
                sum += 1;
            if (physician == true)
                sum += 2;
            if (physician_Assistant == true)
                sum += 3;
            return sum;
        }

        public async Task<int> GetProviderSum(Provider p, bool primary_Care, int sum)
        {
            int val;
            if (primary_Care)
            {
                switch (sum)
                {
                    case 1:
                        val = p.all_nurse_practitioners;
                        break;
                    case 2:
                        val = p.all_physicians;
                        break;
                    case 3:
                        val = p.all_physician_assistants;
                        break;
                    case 4:
                        val = p.all_nurse_practitioners + p.all_physician_assistants;
                        break;
                    case 5:
                        val = p.all_physicians + p.all_physician_assistants;
                        break;
                    case 6:
                        val = p.all_providers;
                        break;
                    case 0:
                        val = -1;
                        break;
                    default:
                        val = -2;
                        break;
                }
            }
            else
            {
                switch (sum)
                {
                    case 1:
                        val = p.all_primary_care_nurse_practitioners;
                        break;
                    case 2:
                        val = p.all_primary_care_physicians;
                        break;
                    case 3:
                        val = p.all_primary_care_physician_assistants;
                        break;
                    case 4:
                        val = p.all_primary_care_nurse_practitioners + p.all_primary_care_physician_assistants;
                        break;
                    case 5:
                        val = p.all_primary_care_physicians + p.all_primary_care_physician_assistants;
                        break;
                    case 6:
                        val = p.all_primary_care_providers;
                        break;
                    case 0:
                        val = -1;
                        break;
                    default:
                        val = -2;
                        break;
                }
            }
            return val;
        }
    }
}
