CREATE TABLE a_cust (
    id          NUMERIC(4) NOT NULL,
    start_date  DATE NOT NULL,
    end_date    DATE NOT NULL,
    amount      NUMERIC(7, 2) NOT NULL,
    status      CHAR(1) NOT NULL
);

COMMENT ON COLUMN a_cust.id IS
    'Customer ID';

COMMENT ON COLUMN a_cust.start_date IS
    'Policy Start Date';

COMMENT ON COLUMN a_cust.end_date IS
    'Policy End Date';

COMMENT ON COLUMN a_cust.amount IS
    'Auto Insurance Premium Amount';

COMMENT ON COLUMN a_cust.status IS
    'Status (Current or Expired)';

ALTER TABLE a_cust ADD CONSTRAINT a_cust_pk PRIMARY KEY ( id );

CREATE TABLE customer (
    id              NUMERIC(4) NOT NULL,
    first_name      VARCHAR(30) NOT NULL,
    last_name       VARCHAR(30) NOT NULL,
    address         VARCHAR(50) NOT NULL,
    gender          CHAR(1),
    marital_status  CHAR(1) NOT NULL,
    type            VARCHAR(1) NOT NULL
);

ALTER TABLE customer
    ADD CONSTRAINT ch_inh_customer CHECK ( type IN (
        'A',
        'H'
    ) );

COMMENT ON COLUMN customer.id IS
    'Customer ID';

COMMENT ON COLUMN customer.first_name IS
    'Customer''s First Name';

COMMENT ON COLUMN customer.last_name IS
    'Customer''s Last Name';

COMMENT ON COLUMN customer.address IS
    'Customer''s Address';

COMMENT ON COLUMN customer.gender IS
    'Customer''s Gender';

COMMENT ON COLUMN customer.marital_status IS
    'Customer''s Marital Status';

COMMENT ON COLUMN customer.type IS
    'Customer Type';

ALTER TABLE customer ADD CONSTRAINT customer_pk PRIMARY KEY ( id );

CREATE TABLE driver (
    license     NUMERIC(5) NOT NULL,
    first_name  VARCHAR(30) NOT NULL,
    last_name   VARCHAR(30) NOT NULL,
    birth_date  DATE NOT NULL
);

COMMENT ON COLUMN driver.license IS
    'Driver''s License Number';

COMMENT ON COLUMN driver.first_name IS
    'Driver''s First Name';

COMMENT ON COLUMN driver.last_name IS
    'Driver''s Last Name';

COMMENT ON COLUMN driver.birth_date IS
    'Driver''s Birth Date';

ALTER TABLE driver ADD CONSTRAINT driver_pk PRIMARY KEY ( license );

CREATE TABLE h_cust (
    id          NUMERIC(4) NOT NULL,
    start_date  DATE NOT NULL,
    end_date    DATE NOT NULL,
    amount      NUMERIC(7, 2) NOT NULL,
    status      CHAR(1) NOT NULL
);

COMMENT ON COLUMN h_cust.id IS
    'Customer ID';

COMMENT ON COLUMN h_cust.start_date IS
    'Policy Start Date';

COMMENT ON COLUMN h_cust.end_date IS
    'Policy End Date';

COMMENT ON COLUMN h_cust.amount IS
    'Home Insurance Premium Amount';

COMMENT ON COLUMN h_cust.status IS
    'Status (Current or Expired)';

ALTER TABLE h_cust ADD CONSTRAINT h_cust_pk PRIMARY KEY ( id );

CREATE TABLE hinsured (
    h_id       NUMERIC(5) NOT NULL,
    pdate      DATE NOT NULL,
    value      NUMERIC(9, 2) NOT NULL,
    area       NUMERIC(7) NOT NULL,
    type       VARCHAR(20) NOT NULL,
    auto_fire  NUMERIC NOT NULL,
    hsecurity  NUMERIC NOT NULL,
    pool       CHAR(1),
    basement   NUMERIC NOT NULL,
    id         NUMERIC(4) NOT NULL
);

COMMENT ON COLUMN hinsured.h_id IS
    'Home ID';

COMMENT ON COLUMN hinsured.pdate IS
    'Purchased Date';

COMMENT ON COLUMN hinsured.value IS
    'Purchased Value';

COMMENT ON COLUMN hinsured.area IS
    'Area of House in Sqft';

COMMENT ON COLUMN hinsured.type IS
    'Type of House';

COMMENT ON COLUMN hinsured.auto_fire IS
    'Auto Fire Notification';

COMMENT ON COLUMN hinsured.hsecurity IS
    'Home Security';

COMMENT ON COLUMN hinsured.pool IS
    'Swimming Pool?';

COMMENT ON COLUMN hinsured.basement IS
    'Basement?';

ALTER TABLE hinsured ADD CONSTRAINT hinsured_pk PRIMARY KEY ( h_id );

CREATE TABLE hinvoices (
    hin_id  NUMERIC(4) NOT NULL,
    pdue    DATE NOT NULL,
    amount  NUMERIC(7, 2) NOT NULL,
    h_id    NUMERIC(5) NOT NULL
);

COMMENT ON COLUMN hinvoices.hin_id IS
    'Invoice ID';

COMMENT ON COLUMN hinvoices.pdue IS
    'Due Date';

COMMENT ON COLUMN hinvoices.amount IS
    'Amount to be paid';

ALTER TABLE hinvoices ADD CONSTRAINT hinvoices_pk PRIMARY KEY ( hin_id );

CREATE TABLE hpayments (
    p_id    NUMERIC(4) NOT NULL,
    "Date"  DATE NOT NULL,
    method  VARCHAR(20) NOT NULL,
    hin_id  NUMERIC(4) NOT NULL
);

COMMENT ON COLUMN hpayments.p_id IS
    'Payment ID';

COMMENT ON COLUMN hpayments."Date" IS
    'Payment Date';

COMMENT ON COLUMN hpayments.method IS
    'Method (PayPal/Credit/Debit/Check)';

ALTER TABLE hpayments ADD CONSTRAINT hpayments_pk PRIMARY KEY ( p_id );

CREATE TABLE vins_and_dr (
    vin      NUMERIC(4) NOT NULL,
    license  NUMERIC(5) NOT NULL
);

ALTER TABLE vins_and_dr ADD CONSTRAINT vins_and_dr_pk PRIMARY KEY ( vin,
                                                                    license );

CREATE TABLE vinsured (
    vin     NUMERIC(4) NOT NULL,
    mmy     VARCHAR(40) NOT NULL,
    status  CHAR(1) NOT NULL,
    id      NUMERIC(4) NOT NULL
);

COMMENT ON COLUMN vinsured.vin IS
    'Vehicle Identification Number';

COMMENT ON COLUMN vinsured.mmy IS
    'Model/Make/Year';

COMMENT ON COLUMN vinsured.status IS
    'Status (L/F/O)';

ALTER TABLE vinsured ADD CONSTRAINT vinsured_pk PRIMARY KEY ( vin );

CREATE TABLE vinvoices (
    vin_id  NUMERIC(4) NOT NULL,
    pdue    DATE NOT NULL,
    amount  NUMERIC(7, 2) NOT NULL,
    vin     NUMERIC(4) NOT NULL
);

ALTER TABLE vinvoices ADD CONSTRAINT vinvoices_pk PRIMARY KEY ( vin_id );

CREATE TABLE vpayments (
    p_id    NUMERIC(4) NOT NULL,
    "Date"  DATE NOT NULL,
    method  VARCHAR(20) NOT NULL,
    vin_id  NUMERIC(4) NOT NULL
);

ALTER TABLE vpayments ADD CONSTRAINT vpayments_pk PRIMARY KEY ( p_id );

ALTER TABLE a_cust
    ADD CONSTRAINT a_cust_customer_fk FOREIGN KEY ( id )
        REFERENCES customer ( id );

ALTER TABLE h_cust
    ADD CONSTRAINT h_cust_customer_fk FOREIGN KEY ( id )
        REFERENCES customer ( id );

ALTER TABLE hinsured
    ADD CONSTRAINT hinsured_h_cust_fk FOREIGN KEY ( id )
        REFERENCES h_cust ( id );

ALTER TABLE hinvoices
    ADD CONSTRAINT hinvoices_hinsured_fk FOREIGN KEY ( h_id )
        REFERENCES hinsured ( h_id );

ALTER TABLE hpayments
    ADD CONSTRAINT hpayments_hinvoices_fk FOREIGN KEY ( hin_id )
        REFERENCES hinvoices ( hin_id );

ALTER TABLE vins_and_dr
    ADD CONSTRAINT vins_and_dr_driver_fk FOREIGN KEY ( license )
        REFERENCES driver ( license );

ALTER TABLE vins_and_dr
    ADD CONSTRAINT vins_and_dr_vinsured_fk FOREIGN KEY ( vin )
        REFERENCES vinsured ( vin );

ALTER TABLE vinsured
    ADD CONSTRAINT vinsured_a_cust_fk FOREIGN KEY ( id )
        REFERENCES a_cust ( id );

ALTER TABLE vinvoices
    ADD CONSTRAINT vinvoices_vinsured_fk FOREIGN KEY ( vin )
        REFERENCES vinsured ( vin );

ALTER TABLE vpayments
    ADD CONSTRAINT vpayments_vinvoices_fk FOREIGN KEY ( vin_id )
        REFERENCES vinvoices ( vin_id );

CREATE OR REPLACE TRIGGER arc_fkarc_1_a_cust BEFORE
    INSERT OR UPDATE OF id ON a_cust
    FOR EACH ROW
DECLARE
    d VARCHAR(1);
BEGIN
    SELECT
        a.type
    INTO d
    FROM
        customer a
    WHERE
        a.id = :new.id;

    IF ( d IS NULL OR d <> 'A' ) THEN
        raise_application_error(-20223, 'FK A_Cust_Customer_FK in Table A_Cust violates Arc constraint on Table Customer - discriminator column Type doesn''t have value ''A''');
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
/

CREATE OR REPLACE TRIGGER arc_fkarc_1_h_cust BEFORE
    INSERT OR UPDATE OF id ON h_cust
    FOR EACH ROW
DECLARE
    d VARCHAR(1);
BEGIN
    SELECT
        a.type
    INTO d
    FROM
        customer a
    WHERE
        a.id = :new.id;

    IF ( d IS NULL OR d <> 'H' ) THEN
        raise_application_error(-20223, 'FK H_Cust_Customer_FK in Table H_Cust violates Arc constraint on Table Customer - discriminator column Type doesn''t have value ''H''');
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
/



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                            11
-- CREATE INDEX                             0
-- ALTER TABLE                             22
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           2
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE MATERIALIZED VIEW LOG             0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
