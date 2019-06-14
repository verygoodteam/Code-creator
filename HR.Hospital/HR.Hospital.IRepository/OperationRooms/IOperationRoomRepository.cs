using HR.Hospital.Common;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;
using System.Collections.Generic;

namespace HR.Hospital.IRepository.OperationRooms
{
    public interface IOperationRoomRepository
    {

        /// <summary>
        /// 查看院区
        /// </summary>
        /// <returns></returns>
        List<AreaDto> GetListArea();

        /// <summary>
        /// 手术室添加
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        int AddOperationRoom(OperationRoom operationRoom);

        /// <summary>
        /// 手术室编辑
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        int UpdateOperationRoom(OperationRoom operationRoom);

        /// <summary>
        /// 查看手术室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperationRoom GetOperationRoom(int id);

        /// <summary>
        /// 是否开启手术间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int EnableOperationRoom(int id);

        /// <summary>
        /// 手术间查看分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="areaId"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        PageHelper<OperationRoom> GetListOperationRoom(int pageIndex, int pageSize, int areaId, string operationName);
    }

}
