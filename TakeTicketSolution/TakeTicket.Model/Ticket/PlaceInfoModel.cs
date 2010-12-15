
#region Using
using System;
#endregion

/*****************************************
功能描述：PlaceInfo的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class PlaceInfoModel
        {        
            private long _placeID;
            /// <summary>
            /// 场馆id
            /// </summary> 
            public long PlaceID
            {
                get { return _placeID; }
                set { _placeID = value; }
            }
            
            private string _name;
            /// <summary>
            /// 场馆名称
            /// </summary> 
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            private int _areaID;
            /// <summary>
            /// 区域id
            /// </summary> 
            public int AreaID
            {
                get { return _areaID; }
                set { _areaID = value; }
            }
            
            private int _cityID;
            /// <summary>
            /// 城市id
            /// </summary> 
            public int CityID
            {
                get { return _cityID; }
                set { _cityID = value; }
            }
            
            private string _address;
            /// <summary>
            /// 街道
            /// </summary> 
            public string Address
            {
                get { return _address; }
                set { _address = value; }
            }
            
            private string _intro;
            /// <summary>
            /// 场馆介绍
            /// </summary> 
            public string Intro
            {
                get { return _intro; }
                set { _intro = value; }
            }
            
            private string _imagePath;
            /// <summary>
            /// 图片地址
            /// </summary> 
            public string ImagePath
            {
                get { return _imagePath; }
                set { _imagePath = value; }
            }
            
            private short _status;
            /// <summary>
            /// 状态
            /// </summary> 
            public short Status
            {
                get { return _status; }
                set { _status = value; }
            }
            
            private System.DateTime _createDate;
            /// <summary>
            /// 创建时间
            /// </summary> 
            public System.DateTime CreateDate
            {
                get { return _createDate; }
                set { _createDate = value; }
            }
            
            private System.DateTime _updateDate;
            /// <summary>
            /// 修改时间
            /// </summary> 
            public System.DateTime UpdateDate
            {
                get { return _updateDate; }
                set { _updateDate = value; }
            }
            
        }
}
