using Prop.Api.Domain;

namespace Prop.Api.Services;

public class QuoteCalculator
{
    public decimal CalculatePremium(Quote quote)
    {
        decimal basePremium = 200m;

        if (quote.PropertyArea > 50)
            basePremium += (quote.PropertyArea - 50) * 2m;

        if (quote.PropertyYear < 2000)
            basePremium += 100m;
        else
        {
            basePremium -= 50m;
        }

        if (quote.HasSecuritySystem)
            basePremium *= 0.9m;



        if (quote.RoomNumber > 3)
            basePremium *= 1.1m;
        else
        {
            basePremium *= 1.0m;
        }


        if (quote.ClaimNumber == 0)
            basePremium *= 0.95m; 
        else if (quote.ClaimNumber <= 2)
            basePremium *= 1.1m;
        else if (quote.ClaimNumber > 2)
            basePremium *= 1.25m;

        if (quote.TopFloor == true) 
            basePremium *= 1.1m;
        else
        {
            basePremium *= 1.0m;
        }

        if (quote.FlammableFloor == true)
            basePremium *= 1.2m;
        else
        {
            basePremium *= 1.0m;
        }

        if (quote.Client?.Address?.PermanentResidence == true)
            basePremium *= 1.05m;


        return Math.Round(basePremium, 2);
    }
}
