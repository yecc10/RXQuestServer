using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStructureTypeLib;
using MECMOD;
using INFITF;
using PROCESSITF;
using PPR;

namespace RXQuestServer
{
    class DataType
    {
        /// <summary>
        /// 达索关键值传送器
        /// </summary>
        public class Dsystem
        {
            /// <summary>
            /// 活动Application
            /// </summary>
            public virtual INFITF.Application DSApplication { get; set; }
            public virtual ProcessDocument DSPPRProduct { get; set; }
            public virtual ProcessDocument DSResource { get; set; }
            /// <summary>
            /// 活动Document
            /// </summary>
            public virtual ProcessDocument DSDocument { get; set; }
            /// <summary>
            /// 自定义的零件
            /// </summary>
            public virtual Part PartID{ get; set; }
            /// <summary>
            /// 用户选择集
            /// </summary>
            public virtual Selection  USelection { get; set; }
            /// <summary>
            /// -1 ERR;0 Normal
            /// </summary>
            public virtual int Revalue { get; set; }
        }
    }
}
