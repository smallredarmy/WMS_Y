using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum {
    public enum DelFlagEnum {
        /// <summary>
        /// 正常删除
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 逻辑删除
        /// </summary>
        LogicDelet = 1,

        /// <summary>
        /// 物理删除
        /// </summary>
        PhysicalDelete = 2,
    }
}
