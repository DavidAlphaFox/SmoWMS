using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOWMS.UI.ConsumablesManager;
using SMOWMS.DTOs.InputDTO;
using SMOWMS.Domain.Entity;

namespace SMOWMS.UI.Layout
{
    ////ToolboxItem���ڿ����Ƿ������Զ���ؼ��������䣬true���ӣ�false������
    //[System.ComponentModel.ToolboxItem(true)]
    partial class frmConPORInStoLayout : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// ѡ��/��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plRow_Press(object sender, EventArgs e)
        {
            if (Check.Checked)
                Check.Checked = false;
            else
                Check.Checked = true;
            ((frmConPORInSto)Form).upCheckState();
        }
        /// <summary>
        /// ����ÿ��CheckBox״̬
        /// </summary>
        public void setCheck(Boolean state)
        {
            Check.Checked = state;
        }
        /// <summary>
        /// ��ȡ��ǰ���Ƿ�ѡ��
        /// </summary>
        public Int32 checkNum()
        {
            if (Check.Checked)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// ѡ��/��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            ((frmConPORInSto)Form).upCheckState();
        }
        /// <summary>
        /// ��ȡ�����Ϣ����
        /// </summary>
        /// <returns></returns>
        internal ConPurchaseOrderRowInputDto getData()
        {
            if (Check.Checked)
            {
                ConPurchaseOrderRowInputDto conPOW = new ConPurchaseOrderRowInputDto();
                conPOW.CID = lblName.BindDataValue.ToString();
                conPOW.POROWID = Convert.ToInt32(imgCon.BindDataValue);
                if (numInStoQuant.Value == 0)
                {
                    conPOW.QUANTSTORED = Convert.ToDecimal(lblQuant.Text);
                }
                else
                {
                    if(Convert.ToDecimal(numInStoQuant.Value)> Convert.ToDecimal(lblQuant.Text))
                    {
                        throw new Exception("ʵ������������ɴ��ڿ��������!");
                    }
                    conPOW.QUANTSTORED = Convert.ToDecimal(numInStoQuant.Value);
                }               
                return conPOW;
            }
            else
            {
                return null;
            }
        }
    }
}