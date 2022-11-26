import "./HomePage.css";
import React from "react";
import fb from "../../assets/facebook.png";
import ig from "../../assets/instagram.png";
import li from "../../assets/linkedin.png";
import TopSectionLogo from "../../assets/top-section-image.jpeg";
import CourseComponent from "../../components/CourseComponent/CourseComponent";
function HomePage() {
  return (
    <div className="home-page-container">
      <section className="top-section">
        <img src={TopSectionLogo} alt="" className="top-section-image" />
        <h1 className="top-section-text">Welcome to 4Finance</h1>
      </section>

      <div className="home-page-content">
        {/* ABOUT US */}
        <section className="about-us-section">
          <h2 className="home-page-titles">About Us</h2>
          <p className="about-us-section-text">
            Lorem Ipsum is simply dummy text of the printing and typesetting
            industry. Lorem Ipsum has been the industry's standard dummy text
            ever since the 1500s, when an unknown printer took a galley of type
            and scrambled it to make a type specimen book. It has survived not
            only five centuries, but also the leap into electronic typesetting,
            remaining essentially unchanged. It was popularised in the 1960s
            with the release of Letraset sheets containing Lorem Ipsum passages,
            and more recently with desktop publishing software like Aldus
            PageMaker including versions of Lorem Ipsum.
          </p>
          <p className="about-us-section-text">
            Lorem Ipsum is simply dummy text of the printing and typesetting
            industry. Lorem Ipsum has been the industry's standard dummy text
            ever since the 1500s, when an unknown printer took a galley of type
            and scrambled it to make a type specimen book. It has survived not
            only five centuries, but also the leap into electronic typesetting,
            remaining essentially unchanged. It was popularised in the 1960s
            with the release of Letraset sheets containing Lorem Ipsum passages,
            and more recently with desktop publishing software like Aldus
            PageMaker including versions of Lorem Ipsum.
          </p>
        </section>
        <section className="courses-section">
          <h2 className="course-name">Courses</h2>
          <div className="courses-list">
            <CourseComponent
              name="React.js"
              description="React is one of the most popular frontend libraries React.js to build interactive UI, integrated with one of the best state management tools: 'REDUX'. "
              creditNumber={3}
            />
            <CourseComponent
              name="ASP.Net Core Web API"
              description="ASP.NET Web API is a framework for building HTTP services that can be accessed from any client including browsers and mobile devices. It is an ideal platform for building RESTful applications on the .NET Framework."
              creditNumber={3}
            />
            <CourseComponent
              name="MySQL"
              description="MySQL is a widely used relational database management system. MySQL is free and open-source. MySQL is ideal for both small and large applications."
              creditNumber={3}
            />
          </div>
        </section>
        {/* CONTACT US */}
        <section className="contact-us-section">
          <h2 className="home-page-titles">Contact Us</h2>
          <div className="home-page-contact-us">
            <div className="phone-email-section">
              <h3>
                <a href="tel:+96170610573">Phone Number: +961 70 610 573</a>
              </h3>
              <h3>
                <a href="mailto:4finance@gmail.com">
                  Email: 4finance@gmail.com{" "}
                </a>
              </h3>
            </div>
            <div className="social-media">
              <a href="https://www.facebook.com/HB4Finance?mibextid=ZbWKwL">
                <img src={fb} alt="facebook" className="social-media-logo" />
              </a>
              <a href="https://instagram.com/4_finance_?igshid=YmMyMTA2M2Y= ">
                <img src={ig} alt="instagram" className="social-media-logo" />
              </a>
            </div>
          </div>
        </section>
      </div>
    </div>
  );
}

export default HomePage;
