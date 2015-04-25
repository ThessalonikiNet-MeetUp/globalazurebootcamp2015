package com.example.skgazure2015;

import java.text.SimpleDateFormat;
import java.util.Locale;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

/**
 * Adapter to bind a Lecture List to a view
 */
public class LectureAdapter extends ArrayAdapter<Lecture> {

    /**
     * Adapter context
     */
    Context mContext;

    /**
     * Adapter View layout
     */
    int mLayoutResourceId;

    public LectureAdapter(Context context, int layoutResourceId) {
        super(context, layoutResourceId);

        mContext = context;
        mLayoutResourceId = layoutResourceId;
    }

    /**
     * Returns the view for a specific item on the list
     */
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = convertView;

        final Lecture currentItem = getItem(position);

        if (row == null) {
            LayoutInflater inflater = ((Activity) mContext).getLayoutInflater();
            row = inflater.inflate(mLayoutResourceId, parent, false);
        }

        row.setTag(currentItem);
        final CheckBox checkBox = (CheckBox) row.findViewById(R.id.checkToDoItem);

        checkBox.setText(currentItem.getTitle());
        checkBox.setChecked(false);
        checkBox.setEnabled(true);
        if(currentItem.getWhen()!=null) {
            final TextView whenText = (TextView) row.findViewById(R.id.whenDate);
            final TextView authorText = (TextView) row.findViewById(R.id.author);
            final TextView descriptionText = (TextView) row.findViewById(R.id.description);
            SimpleDateFormat dateFormat = new SimpleDateFormat("MM-dd HH:mm");

            whenText.setText(dateFormat.format(currentItem.getWhen()));
            authorText.setText(currentItem.getAuthor());
            descriptionText.setText(currentItem.getDescription());
        }

        checkBox.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {

                CommentActivity activity = new CommentActivity();
                Intent intent = new Intent(getContext(), CommentActivity.class);
                intent.putExtra("lecture", currentItem.getTitle());
                getContext().startActivity(intent);
               /* if (checkBox.isChecked()) {
                    checkBox.setEnabled(false);
                    if (mContext instanceof LectureActivity) {
                        LectureActivity activity = (LectureActivity) mContext;
                        activity.checkItem(currentItem);
                    }
                }*/
            }
        });

        return row;
    }

}