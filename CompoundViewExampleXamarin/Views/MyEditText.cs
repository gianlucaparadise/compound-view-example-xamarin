using System;
using Android.Content;
using Android.Content.Res;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CompoundViewExampleXamarin.Views
{
    public class MyEditText : ConstraintLayout
    {
        public string Title
        {
            get
            {
                return TitleTextView.Text;
            }
            set
            {
                TitleTextView.Text = value;
            }
        }

        public string Input
        {
            get
            {
                return InputEditText.Text;
            }
            set
            {
                InputEditText.Text = value;
            }
        }

        public string InputHint
        {
            get
            {
                return InputEditText.Hint;
            }
            set
            {
                InputEditText.Hint = value;
            }
        }

        public string Error
        {
            get
            {
                return ErrorTextView.Text;
            }
            set
            {
                ErrorTextView.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    ErrorTextView.Visibility = ViewStates.Gone;
                    TitleTextView.Visibility = ViewStates.Visible;
                }
                else
                {
                    ErrorTextView.Visibility = ViewStates.Visible;
                    TitleTextView.Visibility = ViewStates.Gone;
                }
            }
        }

        public TextInputType InputType
        {
            get
            {
                switch (InputEditText.InputType)
                {
                    //case Android.Text.InputTypes.ClassText:
                    case Android.Text.InputTypes.TextVariationPassword:
                        return TextInputType.Password;

                    //case Android.Text.InputTypes.ClassText:
                    case Android.Text.InputTypes.TextVariationNormal:
                        return TextInputType.Text;

                    default:
                        return TextInputType.Text;
                }
            }
            set
            {
                switch (value)
                {
                    case TextInputType.Password:
                        InputEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
                        break;

                    default:
                    case TextInputType.Text:
                        InputEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationNormal;
                        break;
                }
            }
        }

        public MyEditText(Context context) : base(context)
        {
            Init(context, null);
        }

        public MyEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs);
        }

        public MyEditText(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Init(context, attrs);
        }

        private TextView TitleTextView;
        private TextView ErrorTextView;
        private EditText InputEditText;

        /// <summary>
        /// Inflates the views in the layout.
        /// </summary>
        /// <param name="context">the current context for the view.</param>
        private void Init(Context context, IAttributeSet attrs)
        {

            LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            inflater.Inflate(Resource.Layout.MyEditTextView, this);

            #region Finding Views
            TitleTextView = FindViewById<TextView>(Resource.Id.myedittext_tv_title);
            ErrorTextView = FindViewById<TextView>(Resource.Id.myedittext_tv_error);
            InputEditText = FindViewById<EditText>(Resource.Id.myedittext_et_input);
            #endregion

            // Default values
            Error = "";
            InputType = TextInputType.Text;

            if (attrs != null)
            {
                TypedArray typedArray = Context.ObtainStyledAttributes(attrs, Resource.Styleable.MyEditText);


                if (typedArray.HasValue(Resource.Styleable.MyEditText_title))
                {
                    Title = typedArray.GetString(Resource.Styleable.MyEditText_title);
                }

                if (typedArray.HasValue(Resource.Styleable.MyEditText_input))
                {
                    Input = typedArray.GetString(Resource.Styleable.MyEditText_input);
                }

                if (typedArray.HasValue(Resource.Styleable.MyEditText_inputHint))
                {
                    InputHint = typedArray.GetString(Resource.Styleable.MyEditText_inputHint);
                }

                if (typedArray.HasValue(Resource.Styleable.MyEditText_error))
                {
                    Error = typedArray.GetString(Resource.Styleable.MyEditText_error);
                }

                if (typedArray.HasValue(Resource.Styleable.MyEditText_inputType))
                {
                    InputType = (TextInputType)typedArray.GetInt(Resource.Styleable.MyEditText_inputType, (int)TextInputType.Text);
                }

                typedArray.Recycle();
            }
        }

        public enum TextInputType
        {
            Text,
            Password
        }
    }
}
