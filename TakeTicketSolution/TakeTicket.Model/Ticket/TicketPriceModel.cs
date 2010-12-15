
#region Using
using System;
#endregion

/*****************************************
功能描述：TicketPrice的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class TicketPriceModel
        {        
            private long _priceID;
            /// <summary>
            /// 价格id
            /// </summary> 
            public long PriceID
            {
                get { return _priceID; }
                set { _priceID = value; }
            }
            
            private long _stageID;
            /// <summary>
            /// 场次id
            /// </summary> 
            public long StageID
            {
                get { return _stageID; }
                set { _stageID = value; }
            }
            
            private decimal _price;
            /// <summary>
            /// 价格
            /// </summary> 
            public decimal Price
            {
                get { return _price; }
                set { _price = value; }
            }
            
            private int _category;
            /// <summary>
            /// 价格类别
            /// </summary> 
            public int Category
            {
                get { return _category; }
                set { _category = value; }
            }
            
            private string _categoryIntro;
            /// <summary>
            /// 类别介绍
            /// </summary> 
            public string CategoryIntro
            {
                get { return _categoryIntro; }
                set { _categoryIntro = value; }
            }
            
            private int _number;
            /// <summary>
            /// 数量
            /// </summary> 
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }
            
        }
}
