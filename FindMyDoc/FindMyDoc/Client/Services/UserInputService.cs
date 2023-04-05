using FindMyDoc.Shared;
using Microsoft.AspNetCore.Authorization;

namespace FindMyDoc.Client.Services
{
    public class UserInputService
    {
        public int GetProviderNum(Provider p, bool primary_Care, bool physician, bool nurse, bool physician_Assistant)
        {
            int sum = 0;
            int val;
            if (nurse == true)
                sum += 1;
            if (physician == true)
                sum += 3;
            if (physician_Assistant == true)
                sum += 5;
            if (!primary_Care)
            {
                switch (sum)
                {
                    case 1:
                        val = p.all_nurse_practitioners;
                        break;
                    case 3:
                        val = p.all_physicians;
                        break;
                    case 5:
                        val = p.all_physician_assistants;
                        break;
                    case 4:
                        val = p.all_nurse_practitioners + p.all_physicians;
                        break;
                    case 6:
                        val = p.all_physician_assistants + p.all_nurse_practitioners;
                        break;
                    case 8:
                        val = p.all_physicians + p.all_physician_assistants;
                        break;
                    case 9:
                        val = p.all_providers;
                        break;
                    case 0:
                        val = -1;
                        break;
                    default:
                        val = -1;
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
                    case 3:
                        val = p.all_primary_care_physicians;
                        break;
                    case 5:
                        val = p.all_primary_care_physician_assistants;
                        break;
                    case 4:
                        val = p.all_primary_care_nurse_practitioners + p.all_primary_care_physicians;
                        break;
                    case 6:
                        val = p.all_primary_care_physician_assistants + p.all_primary_care_nurse_practitioners;
                        break;
                    case 8:
                        val = p.all_primary_care_physicians + p.all_primary_care_physician_assistants;
                        break;
                    case 9:
                        val = p.all_primary_care_providers;
                        break;
                    case 0:
                        val = -1;
                        break;
                    default:
                        val = -1;
                        break;
                }
            }
            if(val == -1)
            {
                return 0;
            }
            else
                return val;
        }
    }
}
