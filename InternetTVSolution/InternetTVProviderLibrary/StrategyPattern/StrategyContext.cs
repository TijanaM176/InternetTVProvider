using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    public class StrategyContext
    {
        private IStrategy iStrategy;

        public StrategyContext()
        {

        }

        public StrategyContext(IStrategy iStrategy)
        {
            this.iStrategy = iStrategy;
        }

        public void setStrategy(IStrategy iStrategy)
        {
            this.iStrategy = iStrategy;
        }

        public void ExecuteStrategy()
        {
            iStrategy.execute();
        }

    }
}
