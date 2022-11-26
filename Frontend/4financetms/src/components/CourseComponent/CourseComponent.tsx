import React from "react";
import "./CourseComponent.css";
type CoursePropsType = {
  name: string;
  description: string;
  creditNumber: number;
};
function CourseComponent(props: CoursePropsType) {
  return (
    <div className="course-component-container">
      <h2 className="course-title">Title: {props.name}</h2>
      <p className="course-description">Description: {props.description}</p>
      <h4 className="course-credits">
        Number of Credits: {props.creditNumber}
      </h4>
    </div>
  );
}

export default CourseComponent;
