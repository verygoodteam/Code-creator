using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class SolitaireSet
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Shift { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SolitaireCycle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SolitaireGroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupMember { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupLeader { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SortId { get; set; }

    }
}
