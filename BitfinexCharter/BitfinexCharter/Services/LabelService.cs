using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitfinexCharter.Services
{
    public class LabelService
    {
        delegate void SetTextCallback(Control entity, string text);

        private static void SetText(Control entity, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (entity.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(SetText);
                entity.Invoke(callback, new object[] { entity, text });
            }
            else
            {
                entity.Text = text;
            }
        }

        public static void RefreshLabel(Control entity, string newValue)
        {
            if (entity.InvokeRequired)
            {
                SetText(entity, newValue);
            }
            else
            {
                entity.Text = newValue;
                entity.Invalidate();
                entity.Update();
                entity.Refresh();
            }
        }

        delegate void RefreshCallback(Control entity);

        private static void CallRefresh(Control entity)
        {

            if (entity.InvokeRequired)
            {
                RefreshCallback callback = new RefreshCallback(CallRefresh);
                entity.Invoke(callback, new object[] { entity });
            }
            else
            {
                entity.Refresh();
            }
        }

        public static void DispatchRefresh(Control entity)
        {
            CallRefresh(entity);
        }


        delegate void AddItemCallback(Control entity, string item);

        public static void AddItem(Control entity, string item)
        {
            if (entity.InvokeRequired)
            {
                AddItemCallback callback = new AddItemCallback(AddItem);
                entity.Invoke(callback, new object[] { entity, item });
            }
            else
            {
                ((ListBox)(entity)).Items.Add(item);
            }
        }

        delegate void ToolStripSetTextCallback(ToolStripStatusLabel entity, string text);

        public static void ToolStripSetText(ToolStripStatusLabel entity, string text)
        {
            var toolStrip = entity.GetCurrentParent();

            if (toolStrip.InvokeRequired)
            {
                ToolStripSetTextCallback callback = new ToolStripSetTextCallback(ToolStripSetText);
                toolStrip.Invoke(callback, new object[] { entity, text });
            }
            else
            {
                entity.Text = text; ;
            }
        }
    }
}
