using System;
using System.Collections.Generic;
using HR.Hospital.Common;
using HR.Hospital.Model;
using System.Linq;
using HR.Hospital.IRepository;
using HR.Hospital.IRepository.OperationRooms;
using HR.Hospital.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace HR.Hospital.Repository.OperationRooms
{
    public class OperationRoomRepository : IOperationRoomRepository
    {
        /// <summary>
        /// 实例化EF上下文对象
        /// </summary>
        private readonly hospitaldbContext _context = new hospitaldbContext();



        /// <summary>
        /// 获取手术间单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationRoom GetOperationRoom(int id)
        {
            var firstOrDefault = _context.Operationroom.FirstOrDefault(p => p.Id == id);
            return firstOrDefault;
        }

        /// <summary>
        /// 是否开启手术间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EnableOperationRoom(int id)
        {
            var area = _context.Operationroom.FirstOrDefault(p => p.Id == id);
            if (area != null) area.EnableOperation = 3;
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 查询院区的Id 名字
        /// </summary>
        /// <returns></returns>
        public List<AreaDto> GetListArea()
        {

            var listArea = _context.QueryAreaDto.FromSql("select Id,AreaName from Area ").ToList();
            return listArea;
        }

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        public int AddOperationRoom(OperationRoom operationRoom)
        {
            _context.Operationroom.Add(operationRoom);
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 修改手术间
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        public int UpdateOperationRoom(OperationRoom operationRoom)
        {
            var firstOrDefault = _context.Operationroom.FirstOrDefault(p => p.Id == operationRoom.Id);
            if (firstOrDefault != null)
            {
                firstOrDefault.OperationName = operationRoom.OperationName;
                firstOrDefault.AreaId = operationRoom.AreaId;
                firstOrDefault.OperationRemark = operationRoom.OperationRemark;
            }
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 实现分页条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="areaId"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        public PageHelper<OperationRoom> GetListOperationRoom(int pageIndex, int pageSize, int areaId, string operationName)
        {
            var pageHelperOperationRoom = new PageHelper<OperationRoom>();
            if (areaId == 0)
            {
                var listArea = _context.Operationroom.OrderBy(p => p.Id).Where(p => p.OperationName.Contains(operationName)).Take((pageIndex - 1) * pageSize).Skip(pageSize).ToList();
                pageHelperOperationRoom.PageSizes = listArea.Count();
                pageHelperOperationRoom.PageList = listArea;
            }
            else
            {
                var listArea = _context.Operationroom.OrderBy(p => p.Id).Where(p => p.OperationName.Contains(operationName) || p.AreaId.Equals(areaId)).Take((pageIndex - 1) * pageSize).Skip(pageSize).ToList();
                pageHelperOperationRoom.PageSizes = listArea.Count();
                pageHelperOperationRoom.PageList = listArea;
            }
            return pageHelperOperationRoom;
        }


    }
}
