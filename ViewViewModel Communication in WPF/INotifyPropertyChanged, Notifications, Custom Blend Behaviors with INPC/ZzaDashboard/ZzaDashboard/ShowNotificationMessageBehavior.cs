﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace ZzaDashboard
{
    public class ShowNotificationMessageBehavior:Behavior<ContentControl>
    {


        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowNotificationMessageBehavior), new PropertyMetadata(null, OnMessageChanged));

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
                return;

            ShowNotificationMessageBehavior behavior = (ShowNotificationMessageBehavior) d;

            behavior.AssociatedObject.Content = e.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (sender, args) =>
            {
                AssociatedObject.Visibility = Visibility.Collapsed;
            };
        }
    }
}